using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    public interface IProductRepository
    {
        public ICollection<Product> getallProducts();
    }
}
