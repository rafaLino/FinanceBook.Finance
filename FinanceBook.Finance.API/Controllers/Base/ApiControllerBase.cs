using FinanceBook.Finance.API.Attributes;
using FinanceBook.Finance.Application.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace FinanceBook.Finance.API.Controllers.Base
{
    /// <summary>
    /// Controller base for finance api project
    /// </summary>
    [ApiKey]
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns>IActionResult</returns>
        internal IActionResult OkOrBadRequest(Response response) => response.Invalid
            ? BadRequest(BadRequestErrorDetails(response.Errors))
            : Ok(response.Result);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns>IActionResult</returns>
        internal IActionResult CreatedOrBadRequest(Response response) => response.Invalid
            ? BadRequest(BadRequestErrorDetails(response.Errors))
            : Created(Request.Path, response.Result);

        private ErrorDetails BadRequestErrorDetails(IEnumerable<string> errors) =>
            new()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = errors,
                Tag = "<ValidateException>"
            };
    }
}
