using Microsoft.AspNetCore.Mvc;
using MyWebApi.Interface.Product;
using MyWebApi.Ioc;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public ActionResult Get()
        {
            ServiceLocator.Current.GetInstance<IMyBusinessClass>().MyBusinessMethod();
            return Ok();
        }
    }
}
