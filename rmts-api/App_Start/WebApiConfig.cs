using System.Web.Http;
using Newtonsoft.Json.Serialization;
using RMTS.API.Providers;

namespace RMTS.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

			// Dit zorgt ervoor dat de JSON resultaten in camelCase zijn ipv. PascalCase.
			// Zou problemen moeten voorkomen aan de frontend.
	        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
	        config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

			// Web API routes
			// CustomDirectRouteProvider zorgt ervoor dat de controllers de route namen overkunnen nemen van BasicController.
			config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
		}
    }
}
