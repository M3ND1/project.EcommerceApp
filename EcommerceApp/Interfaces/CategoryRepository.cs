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

        public ICollection<Category> GetAllCategories()
        {
            var allCategories = _context.Categories.ToList();
            
            return allCategories;
        }

    }
}
