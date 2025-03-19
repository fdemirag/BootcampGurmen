using Bootcamp.API.DTOs;
using Bootcamp.API.Events;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Commands
{
    public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, ResponseDto<int>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductInsertCommandHandler(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }


        public async Task<ResponseDto<int>> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            var id = await _productRepository.Save(request);
            return ResponseDto<int>.Success(id,201);
        }
    }
}
