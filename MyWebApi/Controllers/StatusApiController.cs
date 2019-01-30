using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatusApiController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public async Task<ActionResult> Ping([FromRoute] int id)
        {
            return Ok();
        }
    }
}