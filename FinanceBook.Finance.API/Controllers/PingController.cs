using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceBook.Finance.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public string Get([FromServices] ILogger<PingController> logger)
        {
            logger.LogInformation("PING PONG");
            return "Pong";
        }
    }
}
