using FinanceBook.Finance.API.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Attributes
{
    /// <summary>
    /// api key Attribute
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            ApiKeySettings settings = new();
            configuration.GetSection(ApiKeySettings.ApiKeySectionName).Bind(settings);
            
            if (!context.HttpContext.Request.Headers.TryGetValue(settings.Key, out var extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.HttpContext.Response.WriteAsJsonAsync("api key is missing");
                return;
            }

            if (!settings.Value.Equals(extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.HttpContext.Response.WriteAsJsonAsync("access denied");
                return;
            }

            await next();
        }
    }
}
