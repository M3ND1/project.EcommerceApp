using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateProductAsync(ProductVM productVM)
        {
            var product = new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                ImageUrl = productVM.ImageUrl,
                Price = productVM.Price,
                CreatedAt = DateTime.UtcNow,
                Color = productVM.Color,
                Width = productVM.Width,
                Height = productVM.Height,
                Length = productVM.Length,
                Weight = productVM.Weight,
                Material = productVM.Material
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            //relation
            var productCategory = new Models.ProductCategory
            {
                CategoryId = productVM.SelectedCategoryId,
                ProductId = product.Id
            };
            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            var deletedProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (deletedProduct == null)
                return true;

            return false;
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            var allProducts = await _context.Products.ToListAsync();
            return allProducts;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product!;
        }

        public async Task<Product> GetProductDetailsByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(p => p.Reviews)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            var data = await _context.Products.Where(n => n.Name.Contains(name)).ToListAsync()!;
            return data;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductVM productVM)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = productVM.Name;
                existingProduct.Description = productVM.Description;
                existingProduct.ImageUrl = productVM.ImageUrl;
                existingProduct.Price = productVM.Price;
                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
