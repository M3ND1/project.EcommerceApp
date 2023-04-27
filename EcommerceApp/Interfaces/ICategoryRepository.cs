﻿using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public bool UpdateCategory(int id, Category category);
        public void CreateCategory(Category category);
        public bool DeleteCategory(int id);
    }
}