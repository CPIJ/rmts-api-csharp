using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace RMTS.API.Security
{
	public class ApiKeyHeader : IOperationFilter
	{
		public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
		{
			if (operation.parameters == null)
				operation.parameters = new List<Parameter>();

			operation.parameters.Add(new Parameter
			{
				name = ApiKeyConfig.Name,
				@in = "header",
				type = "string",
				description = "Authorize via an API Key",
				required = true
			});
		}
	}
}