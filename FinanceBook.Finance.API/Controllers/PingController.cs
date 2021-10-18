using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FinanceBook.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public PingController()
        {

        }
        [HttpGet]
        public string Get([FromServices] ILogger<PingController> logger)
        {
            logger.LogInformation("PING PONG");
            return "Pong";
        }

        [HttpGet("[action]")]
        public IActionResult Serilog([FromServices] IConfiguration config)
        {
            return Ok(config.GetValue<string>("Serilog:WriteTo:0:Args:Uri"));
        }
    }
}
