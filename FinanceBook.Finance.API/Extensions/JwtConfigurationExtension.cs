using FinanceBook.Finance.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FinanceBook.Finance.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class JwtConfigurationExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddJwtAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings settings = new();
            configuration.GetSection(JwtSettings.SectionName).Bind(settings);

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(config =>
             {
                 var signinKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(settings.Secret));
                 config.TokenValidationParameters = new TokenValidationParameters
                 {
                     IssuerSigningKey = signinKey,
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = false,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = settings.Issuer,
                     ValidAudience = settings.Audience,
                 };
             });

        }
    }
}
