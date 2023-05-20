using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;

namespace EcommerceApp.Interfaces.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateProduct(ProductVM productVM)
        {
            var product = new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                ImageUrl = productVM.ImageUrl,
                Price = productVM.Price,
                CreatedAt = DateTime.UtcNow
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            //relation
            var productCategory = new Models.ProductCategory
            {
                CategoryId = productVM.SelectedCategoryId,
                ProductId = product.Id
            };
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            var deletedProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            if (deletedProduct == null)
                return true;

            return false;
        }

        public ICollection<Product> GetAllProducts()
        {
            var allProducts = _context.Products.ToList();
            return allProducts;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product!;
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            var data = _context.Products.Where(n => n.Name.Contains(name)).ToList()!;
            return data;
        }

        public bool UpdateProduct(int id, ProductVM productVM)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = productVM.Name;
                existingProduct.Description = productVM.Description;
                existingProduct.ImageUrl = productVM.ImageUrl;
                existingProduct.Price = productVM.Price;
                _context.Products.Update(existingProduct);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
