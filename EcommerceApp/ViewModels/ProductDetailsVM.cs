using EcommerceApp.Models;

namespace EcommerceApp.ViewModels
{
    public class ProductDetailsVM
    {
        public Product? Product { get; set; }
        public ICollection<Product>? SimilarProducts { get; set; }
    }
}
