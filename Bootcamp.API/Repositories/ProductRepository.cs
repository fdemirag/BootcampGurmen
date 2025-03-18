using Bootcamp.API.Models;
using Dapper;
using System.Data;

namespace Bootcamp.API.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Product>> GetAll() 
        {
            var query = "select*from products";
            var products = await _connection.QueryAsync<Product>(query);

            return products.ToList();
        }
    }
        
}
