using EcommerceApp.Data;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ProductCategory
{
    public interface IProductCategoryRepository
    {
        public Task<(List<Category> categories, List<EcommerceApp.ViewModels.ProductVM> products)> GetAllProductCategoriesAsync();
        public Task<List<ProductVM>> GetProductCategoriesAsync();
        public Task<List<ProductVM>> GetProductByCategoryIdAsync(int categoryId);
        public Task<ProductDetailsVM> GetSimilarProductsByIdAsync(int productId);
    }
}
