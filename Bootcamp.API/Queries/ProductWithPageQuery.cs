using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Queries
{
    public class ProductWithPageQuery:IRequest<ResponseDto<List<ProductDto>>>
    {
        public int Page {  get; set; }
        public int PageSize { get; set; }
    }
}
