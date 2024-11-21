using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TarjetasCuentasAPI.SwaggerFilters
{
    public class AddHeaderParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "API_KEY",
                In = ParameterLocation.Header,
                Required = true,
                Description = "Api key",
                AllowEmptyValue = false
            });
        }
    }
}
