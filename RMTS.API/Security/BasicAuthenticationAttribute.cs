using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RMTS.Backend.Data.Repository.Implementations.Entity_Framework;
using RMTS.Backend.Data.Service.Implementation;
using RMTS.Backend.Data.Service.Interface;

namespace RMTS.API.Security
{
	public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
	{
		private readonly IUserService userService = new UserService(new EfUserRepository());

		public override void OnAuthorization(HttpActionContext actionContext)
		{
			if (actionContext.Request.Headers.Authorization == null)
			{
				actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
			}
			else
			{
				string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
				string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
				var usernameAndPassword = decodedAuthenticationToken.Split(':');
				string username = usernameAndPassword[0];
				string password = usernameAndPassword[1];

				if (userService.Authenticate(username, password))
				{
					Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
				}
				else
				{
					actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
				}
			}
		}
	}
}