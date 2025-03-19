using System.Text.Json.Serialization;
using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Commands
{
    public class ProductInsertCommand : IRequest<ResponseDto<int>>
    { 
        public ProductDto newProduct { get; set; }
    }
}