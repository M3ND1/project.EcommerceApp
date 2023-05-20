using EcommerceApp.ViewModels;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;

namespace EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories
{
    public interface IProductCategoryOrderRepository
    {
        ICollection<ProductCategoryOrderVM> GetAllProductCategoriesOrders();
    }
}
