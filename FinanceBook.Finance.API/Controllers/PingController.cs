using Microsoft.AspNetCore.Mvc;


namespace FinanceBook.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Pong";
        }
    }
}
