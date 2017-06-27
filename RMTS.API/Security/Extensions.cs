using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace RMTS.API.Security
{
	public static class Extensions
	{
		public static bool IsAllowed(this HttpRequestMessage request, IEnumerable<string> options)
		{
			string requestUri = request.RequestUri.AbsolutePath.ToLower();

			string refferer = string.Empty;

			if (request.Headers.Referrer != null) refferer = request.Headers.Referrer.AbsolutePath.ToLower();

			return options.Any(o => requestUri.Contains(o) || refferer.Contains(o));
		}
	}
}