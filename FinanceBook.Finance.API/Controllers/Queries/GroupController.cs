using FinanceBook.Finance.API.Controllers.Base;
using FinanceBook.Finance.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Queries
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ApiControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="financeQueries"></param>
        /// <param name="accountId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get([FromServices] IFinanceQueries financeQueries, Guid accountId, CancellationToken cancellationToken)
        {
            return Ok(await financeQueries.GetFinanceAsync(accountId, cancellationToken));
        }
    }
}
