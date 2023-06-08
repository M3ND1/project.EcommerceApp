using EcommerceApp.Data;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.ProductCategory
{
    public interface IProductCategoryRepository
    {
        public (List<Category> categories, List<EcommerceApp.ViewModels.ProductVM> products) GetAllProductCategories();
        public List<ProductVM> GetProductCategories();
        public List<ProductVM> GetProductByCategoryId(int categoryId);
        public ProductDetailsVM GetSimilarProductsById(int productId);
    }
}
