using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using MediatR;

namespace Bootcamp.API.Queries
{
    public class ProductWithPageQueryHandler : IRequestHandler<ProductWithPageQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public ProductWithPageQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<ResponseDto<List<ProductDto>>> Handle(ProductWithPageQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAll().Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);
            var productDtos = new List<ProductDto>();
            products.ToList().ForEach(x => productDtos.Add(new ProductDto(x)));
            return Task.FromResult(ResponseDto<List<ProductDto>>.Success(productDtos, 200));
        }
    }
}
