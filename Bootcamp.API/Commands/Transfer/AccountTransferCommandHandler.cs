using Bootcamp.API.DTOs;  
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Commands.Transfer;

public class AccountTransferCommandHandler:IRequestHandler<AccountTransferCommand,ResponseDto<NoContent>>
{
    
    private readonly IProductRepository _productRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly UnitOfWork _unitOfWork;

    
    public AccountTransferCommandHandler(IProductRepository productRepository, IAccountRepository accountRepository, UnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
    }

  

    public async Task<ResponseDto<NoContent>> Handle(AccountTransferCommand request, CancellationToken cancellationToken)
    {

        await _productRepository.Save(new ProductInsertCommand()
        {
            newProduct = new ProductDto()
            {
                CategoryId = 1,
                Name = "Kalem 5000",
                Price = 100,
                Stock = 200,
                Color = "Red"

            }
        });




     

        await _accountRepository.Withdraw(request.Sender, 100);


        throw new Exception("işlem hatası meydana geldi");
        await _accountRepository.Deposit(request.Receiver, 100);


        _unitOfWork.Commit();




        return ResponseDto<NoContent>.Success(200);







        
    }
}