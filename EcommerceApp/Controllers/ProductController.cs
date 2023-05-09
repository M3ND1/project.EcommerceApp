using EcommerceApp.Data;
using EcommerceApp.Interfaces;
using EcommerceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var data = _productRepository.GetAllProducts();
            return View(data);
        }
        [HttpPost]
        public IActionResult Search([FromForm] string inputValue)
        {
            var data = _productRepository.SearchByName(inputValue);
            //ViewData["SearchResults"] = data; //pass viewdata to partialview of products
            return PartialView("_ProductSearchResults", data);
        }
        public IActionResult Create()
        {
            var productVM = new ProductVM
            {
                Categories = _categoryRepository.GetAllCategories().ToList()
            };
            return View(productVM);
        }
        [HttpPost]
        public IActionResult CreateProduct([Bind("Name, Description, ImageUrl,Price,CreatedAt, SelectedCategoryId")] ProductVM productVM)
        {
            if(ModelState.IsValid)
            {
                _productRepository.CreateProduct(productVM);
                return RedirectToAction(nameof(Index));
            } else
            {
                return BadRequest();
            }
        }
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            if(product == null)
            {
                BadRequest();
            }
            return View(product);
        }
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("EditProduct")]
        public IActionResult EditProduct(int id, [Bind("Name, Description, ImageUrl,Price")] ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = _productRepository.UpdateProduct(id, productVM);
                if(isUpdated)
                {
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return View();
                }
            }
            return View(productVM);//temporary
        }
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            bool productDeletion = _productRepository.DeleteProduct(id);
            if(productDeletion)
                return RedirectToAction(nameof(Index));
            else 
                return BadRequest(); //temoprary
        }
    }
}
