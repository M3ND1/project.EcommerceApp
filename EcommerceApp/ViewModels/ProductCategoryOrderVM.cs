using EcommerceApp.Models;

namespace EcommerceApp.ViewModels
{
    public class ProductCategoryOrderVM
    {
        public Product? Product { get; set; }
        public Category Categories { get; set; }
        public Order Order { get; set; }
        //public string OrderName { get; set; }
        //temporary 
    }
}
