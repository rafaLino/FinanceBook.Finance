using FinanceBook.Finance.API.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceBook.Finance.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class CorsConfigurationExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupCors(this IServiceCollection services, IConfiguration configuration)
        {
            CorsSettings setting = new();
            configuration.GetSection(CorsSettings.SectionName).Bind(setting);

            services.AddCors(setup =>
            {
                setup.AddPolicy(CorsSettings.PolicyName, builder =>
                {
                    builder.WithOrigins(setting.AllowedOrigins);
                    builder.WithHeaders(setting.AllowedHeaders);
                    builder.WithMethods(setting.AllowedMethods);
                });
            });
        }
    }
}
