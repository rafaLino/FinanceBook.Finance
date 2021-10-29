using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Middlewares
{
    /// <summary>
    /// Api key middleare
    /// </summary>
    public static class ApiKeyMiddleware
    {
        private const string _apiKey = "X-API-KEY";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="configuration"></param>
        public static void UseApiKeyValidation(this IApplicationBuilder application, IConfiguration configuration)
        {
            application.Use(async (context, next) =>
           {
               string apiKeyValue = configuration.GetValue<string>(_apiKey);
               bool exist = context.Request.Headers.TryGetValue(_apiKey, out StringValues values);

               if (exist)
               {
                   string value = values.Single();
                   if (apiKeyValue != value)
                   {
                       context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                       await context.Response.WriteAsJsonAsync("access denied");
                   }
                   else
                       await next();
               }
               else
               {
                   context.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                   await context.Response.WriteAsJsonAsync("api key is missing");
               }

           });
        }
    }
}
