using Bootcamp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            
            return Ok(_productRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {


            return Ok(_productRepository.GetById(id));
        }
        // S  s

        [HttpPost]
        public IActionResult SaveProduct(Product newProduct)
        {
            _productRepository.Save(newProduct);

            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
          //  return Created($"api/products/{newProduct.Id}",newProduct);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product updateProduct)
        {
            _productRepository.Update(updateProduct);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            return Ok();
        }
    }
}
