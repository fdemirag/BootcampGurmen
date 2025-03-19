using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Commands.Transfer;

public class AccountTransferCommand:IRequest<ResponseDto<NoContent>>
{
    public int Sender { get; set; }
    public int Receiver { get; set; }
    public decimal Amount { get; set; }
}