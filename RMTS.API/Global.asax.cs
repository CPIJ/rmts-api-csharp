using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using RMTS.API;
using RMTS.API.MessageHandlers;

namespace rmts_api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

	        GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiKeyHandler());
			GlobalConfiguration.Configuration.MessageHandlers.Add(new AutorisationHandler());
		}
    }
}
