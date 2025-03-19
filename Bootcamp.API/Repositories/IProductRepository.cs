using Bootcamp.API.Commands;
using Bootcamp.API.Commands.ProductDelete;
using Bootcamp.API.Commands.Transfer;
using Bootcamp.API.Models;

namespace Bootcamp.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAllWithPage(int page, int pageSize);
        Task<List<Product>> GetAllWithPageParameters(int page, int pageSize);
        Task<int> Save (ProductInsertCommand  productInsertCommand);
        Task<bool> Update(ProductUpdateCommand updateCommand);
        Task<bool> Delete(ProductDeleteCommand deleteCommand);
        Task<bool> TransferByStoreProcedure(AccountTransferCommand accountTransferCommand);
        Task<bool> Transfer(AccountTransferCommand accountTransferCommand);
    }
}
