using Bootcamp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductsWithPage/{page:int}/{pageSize:int}")]
        public IActionResult GetProductWithPage(int page,int pageSize) { return Ok(); }

        [HttpGet]
        public IActionResult GetProducts()
        {
            
            return _productService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.GetById(id);

            return new OkObjectResult(result) { StatusCode=result.StatusCode};
        }

        [HttpGet("/api/[controller]/[action]/{id:int}")]
        public IActionResult AnyProduct(int id)
        {
            return Ok();        
        }
        // S  s

        [HttpPost]
        public IActionResult SaveProduct(Product newProduct)
        {
            return _productService.Save(newProduct);

            //return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
          //  return Created($"api/products/{newProduct.Id}",newProduct);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product updateProduct)
        {

            var result = _productService.Update(updateProduct);

            return new OkObjectResult(result) { StatusCode = result.StatusCode };
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {

            return _productService.Delete(id);
        }
    }
}
