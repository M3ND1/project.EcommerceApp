using EcommerceApp.Data;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Interfaces.ProductRepositories;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        public ProductCategoryRepository(AppDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<(List<Category> categories, List<ProductVM> products)> GetAllProductCategoriesAsync() //change name for this method later
        {
            var categories = await _context.Categories.ToListAsync();
            var productsCategory = await _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ToListAsync();

            List<ProductVM> productViewModels = new();
            foreach (var pc in productsCategory)
            {
                var productVM = new ProductVM()
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    Description = pc.Description,
                    ImageUrl = pc.ImageUrl,
                    Price = pc.Price,
                    Color = pc.Color,
                    Width = pc.Width,
                    Height = pc.Height,
                    Length = pc.Length,
                    Weight = pc.Weight,
                    Material = pc.Material,
                    Categories = pc.ProductCategories.Select(pc => pc.Category).ToList()
                };
                productViewModels.Add(productVM);
            }
            return (categories, productViewModels);
        }

        public async Task<List<ProductVM>> GetProductByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductVM>> GetProductCategoriesAsync()
        {
            var productsCategory = await _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .ToListAsync();
            List<ProductVM> productViewModels = new();
            foreach (var pc in productsCategory)
            {
                var productVM = new ProductVM()
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    Description = pc.Description,
                    ImageUrl = pc.ImageUrl,
                    Price = pc.Price,
                    Color = pc.Color,
                    Width = pc.Width,
                    Height = pc.Height,
                    Length = pc.Length,
                    Weight = pc.Weight,
                    Material = pc.Material,
                    Categories = pc.ProductCategories.Select(pc => pc.Category).ToList()
                };
                productViewModels.Add(productVM);
            }
            return (productViewModels);
        }
        public async Task<ProductDetailsVM> GetSimilarProductsByIdAsync(int productId)
        {
            //product reviews categories
            var product = await _productRepository.GetProductDetailsByIdAsync(productId); //tu pobieram PRODUCT
            
            if(product == null)
            {
                return new ProductDetailsVM();
            }
            //similar 
            var categories = product.ProductCategories.Select(pc => pc.CategoryId).ToList(); //all categories


            var similarProducts = await _context.Products
                .Include(p => p.Reviews)
                .Include(p => p.ProductCategories)
                    .Where(p => p.ProductCategories.Any(pc => categories.Contains(pc.CategoryId))).ToListAsync();
            //search for product here
            if (similarProducts != null)
            {
                //Product existingProduct = similarProducts.FirstOrDefault(p => p.Id == productId);
                similarProducts.RemoveAll(p => p.Id == productId);
            }
            var productDetailsVM = new ProductDetailsVM {
                    Product = product,
                    SimilarProducts = similarProducts
            };
                
            return productDetailsVM;
        }
    }
}
