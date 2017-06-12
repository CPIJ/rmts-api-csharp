using System.Web.Http;
using WebActivatorEx;
using RMTS.API;
using RMTS.API.Security;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace RMTS.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "RMTS.API");
	                    c.OperationFilter<ApiKeyHeader>();
                    })
                .EnableSwaggerUi(c =>
                    {
						c.EnableApiKeySupport(ApiKeyConfig.Name, "header");
                    });
        }
    }
}
