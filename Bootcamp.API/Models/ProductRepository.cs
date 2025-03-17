namespace Bootcamp.API.Models
{
    public class ProductRepository:IProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "Kalem 1", Price = 100, Stock = 200 },
            new() { Id = 2, Name = "Kalem 2", Price = 120, Stock = 300 },
            new() { Id = 30, Name = "Kalem 3", Price = 140, Stock = 400 },

        };
        public List<Product> GetAll() => _products;


        public Product GetById(int id) 
        {

            var product =_products.First(p => p.Id == id);
            return product;
        }

        public void Save(Product newProduct) => _products.Add(newProduct);

        public void Delete(int id) 
        { 
        
            var product= _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(product);
        }

        public void Update(Product updateProduct)
        {
            var product = _products.FirstOrDefault(x=>x.Id == updateProduct.Id);

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            product.Stock = updateProduct.Stock;

            var productIndex = _products.FindIndex(x => x.Id == updateProduct.Id);
            _products[productIndex] = product;
        }
    }
}
