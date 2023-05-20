using EcommerceApp.Models;

namespace EcommerceApp.ViewModels
{
    public class ProductCategoryVM
    {
        public List<Category>? Categories { get; set; }
        public List<ProductVM>? ProductCategories { get; set; }
    }
}
