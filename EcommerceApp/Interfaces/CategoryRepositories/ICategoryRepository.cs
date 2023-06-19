using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.CategoryRepositories
{
    public interface ICategoryRepository
    {
        public Task<ICollection<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<IEnumerable<Category>> SearchByNameAsync(string name);
        public Task<bool> UpdateCategoryAsync(int id, Category category);
        public Task CreateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryAsync(int id);
    }
}
