using Bootcamp.API.Commands;
using Bootcamp.API.DTOs;
using Bootcamp.API.Filters;
using Bootcamp.API.Models;
using Bootcamp.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMediator _mediator;

        public ProductsController(ProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet("GetProductsWithPage/{page:int}/{pageSize:int}")]
        public async Task <IActionResult> GetProductWithPage(int page,int pageSize) 
        
        { 
            return Ok(await _mediator.Send(new ProductWithPageQuery(){Page=page,PageSize=pageSize })); 
        
        }

        [CustomExceptionFilter]
        [HttpGet]
        public IActionResult GetProducts()
        {
            //throw new Exception("veritabanına bağlanma problemi");
            return _productService.GetAll();
        }

        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpGet("{id:int}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.GetById(id);

            var resultObject = new OkObjectResult(result) { StatusCode=result.StatusCode};

            return resultObject;
        }

        [HttpGet("/api/[controller]/[action]/{id:int}")]
        public IActionResult AnyProduct(int id)
        {
            return Ok();        
        }
        // S  s

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductRequestDto newProduct)
        {





            await _mediator.Send(new ProductInsertCommand() { Name = newProduct.Name, Price = newProduct.Price.Value, Stock = newProduct.Stock.Value });

            return Created("", null);
            //return _productService.Save(new Product() { Name = newProduct.Name, Price = newProduct.Price, Stock = newProduct.Stock });

            //return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
          //  return Created($"api/products/{newProduct.Id}",newProduct);
        }

        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,Product updateProduct)
        {

            var result = await _mediator.Send(new ProductUpdateCommand() { Id = id,Name=updateProduct.Name,Price=updateProduct.Price.Value,Stock=updateProduct.Stock.Value }) ;



            return new ObjectResult(result) { StatusCode = result.StatusCode };
        }


        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {

            return _productService.Delete(id);
        }
    }
}
