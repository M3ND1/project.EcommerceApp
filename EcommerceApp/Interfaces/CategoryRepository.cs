using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(new Category { Name = category.Name});
            _context.SaveChanges();
            //validation if category was created later (void to bool)
        }

        public bool DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<Category> GetAllCategories()
        {
            var allCategories = _context.Categories.ToList();
            
            return allCategories;
        }

        public Category GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            return category!;
        }

        public IEnumerable<Category> SearchByName(string name)
        {
            return _context.Categories.Where(c => c.Name.Contains(name)).ToList();
        }

        public bool UpdateCategory(int id, Category category)
        {
            //var existingCategory = GetCategoryById(category.Id);
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _context.SaveChanges();
                return true;
            } else return false;
        }
    }
}
