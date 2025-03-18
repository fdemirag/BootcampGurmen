using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Queries.GetAll
{
    public class ProductGetAllQuery : IRequest<ResponseDto<List<ProductDto>>>
    {
    }
}
