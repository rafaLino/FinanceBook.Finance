using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace FinanceBook.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public string Get([FromServices] ILogger<PingController> logger)
        {
            logger.LogInformation("PING PONG");
            return "Pong";
        }
    }
}
