using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]/[action]")]  
    [ApiController]
    public class ExampleController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok("Merhaba Dünya[GET]");
        }
        // S  s

        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok("Merhaba Dünya[Post]");
        }
        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok("Merhaba Dünya[Put]");
        }


        [HttpDelete]
        public IActionResult DeleteProduct()
        {
            return Ok("Merhaba Dünya[Delete]");
        }
    }
}
