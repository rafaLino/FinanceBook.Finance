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
        private const string _apiKey = "X-API-KEY";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            if (!context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.HttpContext.Response.WriteAsJsonAsync("api key is missing");
                return;
            }
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeyValue = configuration.GetValue<string>(_apiKey);

            if (!apiKeyValue.Equals(extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.HttpContext.Response.WriteAsJsonAsync("access denied");
                return;
            }

            await next();
        }
    }
}
