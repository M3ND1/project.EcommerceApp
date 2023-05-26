using EcommerceApp.Data;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public (List<Category> categories, List<EcommerceApp.ViewModels.ProductVM> products) GetAllProductCategories()
        {
            var categories = _context.Categories.ToList();
            var productsCategory = _context.Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ToList();

            List<ProductVM> productViewModels = new();
            foreach(var pc in productsCategory)
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
    }
}
