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

        public IActionResult Index()
        {
            var allCategories = _categoryRepository.GetAllCategories();
            return View(allCategories);
        }
        [HttpPost]
        public IActionResult Search([FromForm] string inputValue)
        {
            var data = _categoryRepository.SearchByName(inputValue);
            return PartialView("_CategorySearchResults", data);
        }
        public IActionResult Details(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
                BadRequest();

            return View(category);
        }
        public IActionResult Create(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
                BadRequest();

            return View(category);
        }
        [HttpPost, ActionName("CreateCategory")]
        public IActionResult CreateCategory([Bind("Name")]Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.CreateCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }
        [HttpPost, ActionName("EditCategory")]
        public IActionResult EditCategory(int id, [Bind("Name")] Category category)
        {
            bool newcategory = _categoryRepository.UpdateCategory(id, category);
            if(!newcategory) BadRequest(); // temporary
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            bool category = _categoryRepository.DeleteCategory(id);
            if(!category) BadRequest();

            return RedirectToAction("Index");
        }
    }
}
