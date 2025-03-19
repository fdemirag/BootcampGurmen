using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Commands.ProductDelete;

public class ProductDeleteCommand:IRequest<ResponseDto<NoContent>>
    
{
    public int Id { get; set; }
}