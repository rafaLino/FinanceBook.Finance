using FinanceBook.Finance.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
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
                 
                 config.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = false,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = settings.Issuer,
                     ValidAudience = settings.Audience,
                     IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(settings.Secret)),
                 };
             });

        }
    }
}
