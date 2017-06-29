using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RMTS.API.Security;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;
using RMTS.Backend.Models;


namespace RMTS.API.MessageHandlers
{
	public class AutorisationHandler : DelegatingHandler
	{
		private readonly IUserService userService = new UserService(new EfUserRepository());

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// Als er via swagger en login een call gedaan wordt hoeft er niet ingelogd te zijn.
			// De gebruiker wordt dan ook zonder probleem doorgelaten.
			if (request.IsAllowed(AuthorizationConfig.UnauthorizedEndpoints)) return await base.SendAsync(request, cancellationToken);

			// Als er geen authorisation aanwezig is is de gebruiker standaard niet geauthoriseerd.
			// Er wordt dan ook geen toegang verleent.
			if (request.Headers.Authorization == null) return request.CreateResponse(HttpStatusCode.Unauthorized);

			var credentials = DecodeCredentials(request.Headers.Authorization.Parameter);

			// Als de authenticatie mislukt wordt de gebruiker niet doorgelaten
			if (!(userService.Authenticate(credentials.Username, credentials.Password))) return request.CreateResponse(HttpStatusCode.Unauthorized);

			return await base.SendAsync(request, cancellationToken);
		}

		private static Credentials DecodeCredentials(string token)
		{
			string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
			var usernameAndPassword = decodedAuthenticationToken.Split(':');
			return new Credentials(usernameAndPassword[0], usernameAndPassword[1]);
		}
	}
}
