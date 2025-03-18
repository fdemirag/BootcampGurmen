using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Commands
{
    public class ProductInsertCommand : IRequest<ResponseDto<NoContent>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}