using FinanceBook.Finance.Application.Core;
using FinanceBook.Finance.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private ILogger<AppException> _logger;
        public ExceptionFilter(ILogger<AppException> logger)
        {
            _logger = logger;
        }
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            ErrorDetails details =
                            context.Exception is AppException ex
                            ? new ErrorDetails { StatusCode = ex.StatusCode, Message = ex.Message, Tag = ex.Tag }
                            : new ErrorDetails
                            {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Message = context.Exception?.Message,
                                Tag = "<UnhandledError>",
                                StackTrace = context.Exception?.StackTrace,
                                TraceId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier
                            };


            _logger.LogError(context.Exception, details.ToString());

            context.HttpContext.Response.StatusCode = details.StatusCode;
            context.HttpContext.Response.ContentType = "application/json";
            context.ExceptionHandled = true;

            await context.HttpContext.Response.WriteAsJsonAsync(details);
        }
    }
}
