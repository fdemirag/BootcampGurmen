
using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Queries.GetAll
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public ProductGetAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<List<ProductDto>>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {


            var products = await _productRepository.GetAll();

            var productDtos = new List<ProductDto>();

            products.ForEach(x => productDtos.Add(new ProductDto(x)));

            return ResponseDto<List<ProductDto>>.Success(productDtos, 200);
        }
    }
}
