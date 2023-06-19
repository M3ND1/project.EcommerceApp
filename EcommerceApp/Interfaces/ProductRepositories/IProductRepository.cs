using EcommerceApp.Models;
using EcommerceApp.ViewModels;

namespace EcommerceApp.Interfaces.ProductRepositories
{
    public interface IProductRepository
    {
        public Task<ICollection<Product>> GetAllProductsAsync();
        public Task CreateProductAsync(ProductVM productVM); //TODO change from void to bool to handle exceptions
        public Task<Product> GetProductByIdAsync(int id);
        public Task<bool> UpdateProductAsync(int id, ProductVM productVM);
        public Task<bool> DeleteProductAsync(int id);
        public Task<IEnumerable<Product>> SearchByNameAsync(string name);
        public Task<Product> GetProductDetailsByIdAsync(int id);
    }
}
