using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
                    Description = "Finance service"

                });

                c.IncludeXmlComments(
                    Path.ChangeExtension(typeof(Startup).Assembly.Location, "xml"));
            });

        }
    }
}
