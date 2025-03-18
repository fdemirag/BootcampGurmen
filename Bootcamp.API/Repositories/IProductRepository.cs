using Bootcamp.API.Models;

namespace Bootcamp.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
    }
}
