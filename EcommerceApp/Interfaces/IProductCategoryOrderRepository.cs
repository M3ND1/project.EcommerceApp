using EcommerceApp.ViewModels;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;

namespace EcommerceApp.Interfaces
{
    public interface IProductCategoryOrderRepository
    {
        Task<ICollection<ProductCategoryOrderVM>> GetAllProductCategoriesOrders();
    }
}
