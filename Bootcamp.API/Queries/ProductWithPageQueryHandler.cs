using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Queries
{
    public class ProductWithPageQueryHandler : IRequestHandler<ProductWithPageQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductWithPageQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        
        public async Task<ResponseDto<List<ProductDto>>> Handle(ProductWithPageQuery request, CancellationToken cancellationToken)
        {
       
        
            var products = await _productRepository.GetAllWithPageParameters(request.Page, request.PageSize);
            return  ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products),200);
            
        }
    }
}
