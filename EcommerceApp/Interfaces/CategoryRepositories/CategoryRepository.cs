using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(new Category { Name = category.Name });
            await _context.SaveChangesAsync();
            //validation if category was created later (void to bool)
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            var allCategories = await _context.Categories.ToListAsync();

            return allCategories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category!;
        }

        public async Task<IEnumerable<Category>> SearchByNameAsync(string name)
        {
            return await _context.Categories.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            //var existingCategory = GetCategoryById(category.Id);
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
