using Microsoft.AspNetCore.Mvc;
using MyWebApi.Interface.Product;
using MyWebApi.Ioc;
using MyWebApi.Models.Product;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] ProductModel product)
        {
            ProductModel result = await ServiceLocator.Current.GetInstance<IProductBusiness>().InsertNewProduct(product);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetProductById([FromRoute] int id)
        {
            ProductModel product = await ServiceLocator.Current.GetInstance<IProductBusiness>().GetProductById(id);
            return Ok(product);
        }
    }
}
