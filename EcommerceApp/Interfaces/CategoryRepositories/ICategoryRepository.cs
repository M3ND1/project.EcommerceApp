using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.CategoryRepositories
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public IEnumerable<Category> SearchByName(string name);
        public bool UpdateCategory(int id, Category category);
        public void CreateCategory(Category category);
        public bool DeleteCategory(int id);
    }
}
