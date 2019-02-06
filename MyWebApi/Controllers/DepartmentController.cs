using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.Interface.Department;
using MyWebApi.Ioc;
using MyWebApi.Models.Department;

namespace MyWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public DepartmentController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostDepartment([FromBody] DepartmentModel department)
        {
            try
            {
                var  result = await ServiceLocator.Current.GetInstance<IDepartmentBusiness>().InsertNewDepartment(department);
                _logger.LogInformation($"Posted Department with Id {result.Id} and Name ${result.Name}");
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e.StackTrace);
                return BadRequest();
            }
        }
    }
}