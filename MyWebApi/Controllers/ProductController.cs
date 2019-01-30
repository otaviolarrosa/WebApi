using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.Interface.Product;
using MyWebApi.Ioc;
using MyWebApi.Models.Product;
using System;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] ProductModel product)
        {
            try
            {
                ProductModel result = await ServiceLocator.Current.GetInstance<IProductBusiness>().InsertNewProduct(product);
                _logger.LogInformation($"Posted Product with Id {result.Id} and Name ${result.Name}");
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetProductById([FromRoute] int id)
        {
            try
            {
                ProductModel product = await ServiceLocator.Current.GetInstance<IProductBusiness>().GetProductById(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);
                return BadRequest();
            }
        }
    }
}
