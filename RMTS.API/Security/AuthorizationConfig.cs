using System.Collections;
using System.Collections.Generic;

namespace RMTS.API.Security
{
	public static class AuthorizationConfig
	{
		public static IEnumerable<string> UnauthorizedEndpoints => new[] { "swagger", "login" };
		public static IEnumerable<string> OpenEndpoints => new[] { "swagger" };
	}
}