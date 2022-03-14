using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace HomeworkTwo
{
    public class OperationFilterClass : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.Parameters is null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
            operation.Parameters.Add(new OpenApiParameter
                { 
                Name="app-version", 
                In = ParameterLocation.Header,
                Description="Write your version",
                Schema = new OpenApiSchema { Type= "double"}
            });
        }
    }
}
