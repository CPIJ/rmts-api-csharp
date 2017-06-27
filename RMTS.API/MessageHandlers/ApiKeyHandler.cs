using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RMTS.API.Security;

namespace RMTS.API.MessageHandlers
{
	public class ApiKeyHandler : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			bool isValidKey = false;
			IEnumerable<string> headers;
			bool apiKeyExists = request.Headers.TryGetValues(ApiKeyConfig.Name, out headers);
			bool isSwagger = request.IsAllowed(AuthorizationConfig.Unprotected);

			if (apiKeyExists)
			{
				string receivedApiKey = headers.FirstOrDefault();
				if (receivedApiKey != null)
				{
					isValidKey = ApiKeyConfig.Keys.ContainsValue(receivedApiKey);
				}
			}

			if (!isValidKey && !isSwagger) return request.CreateResponse(HttpStatusCode.Forbidden, "Bad API Key");

			var response = await base.SendAsync(request, cancellationToken);

			return response;
		}
	}
}