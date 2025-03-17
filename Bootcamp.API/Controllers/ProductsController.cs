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

        [HttpGet]
        public IActionResult GetProducts()
        {
            
            return _productService.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {


            return Ok(_productService.GetById(id));
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
            
            return _productService.Update(updateProduct);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {

            return _productService.Delete(id);
        }
    }
}
