using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceBook.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public string Get([FromServices] ILogger<PingController> logger)
        {
            logger.LogInformation("PING PONG");
            return "Pong";
        }
    }
}
