using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data;
using EcommerceApp.Models;
using EcommerceApp.Interfaces.CategoryRepositories;

namespace EcommerceApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allCategories = await _categoryRepository.GetAllCategoriesAsync();
            return View(allCategories);
        }
        [HttpPost]
        public async Task<IActionResult> Search([FromForm] string inputValue)
        {
            var data = await _categoryRepository.SearchByNameAsync(inputValue);
            return PartialView("_CategorySearchResults", data);
        }
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                BadRequest();

            return View(category);
        }
        public async Task<IActionResult> Create(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                BadRequest();

            return View(category);
        }
        [HttpPost,ActionName("CreateCategory")]
        public async Task<IActionResult> CreateCategory([Bind("Name")]Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateCategoryAsync(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return View(category);
        }
        [HttpPost, ActionName("EditCategory")]
        public async Task<IActionResult> EditCategory(int id, [Bind("Name")] Category category)
        {
            bool newcategory = await _categoryRepository.UpdateCategoryAsync(id, category);
            if(!newcategory) BadRequest(); // temporary
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            bool category = await _categoryRepository.DeleteCategoryAsync(id);
            if(!category) BadRequest();

            return RedirectToAction("Index");
        }
    }
}
