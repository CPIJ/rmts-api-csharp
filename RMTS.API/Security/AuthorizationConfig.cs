using System.Collections;
using System.Collections.Generic;

namespace RMTS.API.Security
{
	public static class AuthorizationConfig
	{
		public static IEnumerable<string> Unauthorized => new[] { "swagger", "login" };
		public static IEnumerable<string> Unprotected => new[] { "swagger" };
	}
}