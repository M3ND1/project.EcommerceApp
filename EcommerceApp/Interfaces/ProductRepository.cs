using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Product> getallProducts()
        {
            var allProducts = _context.Products.ToList();
            return allProducts;
        }
    }
}
