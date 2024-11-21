using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TarjetasCuentasAPI.SwaggerFilters
{
    public class AddHeaderParametersSecurity : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Security == null)
            {
                operation.Security = new List<OpenApiSecurityRequirement>();
            }

            var schema = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "API_KEY"
                }
            };
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [schema] = new List<string>()
            });
        }
    }
}
