using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.IO;

namespace FinanceBook.Finance.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerConfigurationExtension
    {
        /// <summary>
        /// swagger setup
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FinanceBook.Finance.API",
                    Version = "v1",
                    Description = "Finance service",

                });

                c.OperationFilter<AddRequiredHeaderParameter>();

                c.IncludeXmlComments(
                    Path.ChangeExtension(typeof(Startup).Assembly.Location, "xml"));
            });

        }
    }

    internal class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Schema = new OpenApiSchema
                {
                    Type = "string",

                },
                In = ParameterLocation.Header,
                Name = "X-API-KEY",
                Required = false,

            });
        }
    }

}
