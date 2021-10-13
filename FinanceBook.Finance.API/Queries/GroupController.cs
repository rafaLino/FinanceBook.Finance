using FinanceBook.Finance.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Queries
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get([FromServices] IFinanceQueries financeQueries, Guid accountId, CancellationToken cancellationToken)
        {
            return Ok(await financeQueries.GetFinanceAsync(accountId, cancellationToken));
        }
    }
}
