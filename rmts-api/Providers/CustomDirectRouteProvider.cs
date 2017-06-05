using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace RMTS.API.Providers
{
	// Deze klasse wordt gebruikt om te zorgen dat de inheritance werkt bij de controllers.
	// Anders worden de route namen niet meegenomen.
	public class CustomDirectRouteProvider : DefaultDirectRouteProvider
	{
		protected override IReadOnlyList<IDirectRouteFactory>
			GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
		{
			return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>
				(inherit: true);
		}
	}
}