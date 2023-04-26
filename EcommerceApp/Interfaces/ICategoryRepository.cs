using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetAllCategories();
    }
}
