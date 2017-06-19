using System.Collections.Generic;

namespace RMTS.API.Security
{
	internal class ApiKeyConfig
	{
		public static string Name => "API_KEY";
		public static Dictionary<string, string> Keys => new Dictionary<string, string>
		{
			{ "Default", "D4KIaFxISAl4SM16HBDyttE0k" }
		};
	}
}