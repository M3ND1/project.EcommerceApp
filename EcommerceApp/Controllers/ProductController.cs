using EcommerceApp.Data;
using EcommerceApp.Interfaces.CategoryRepositories;
using EcommerceApp.Interfaces.ProductRepositories;
using EcommerceApp.Interfaces.ProductCategory;
using EcommerceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _productRepository.GetAllProductsAsync();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Search([FromForm] string inputValue)
        {
            var data = await _productRepository.SearchByNameAsync(inputValue);
            return PartialView("_ProductSearchResults", data);
        }
        public async Task<IActionResult> Create()
        {
            var productVM = new ProductVM
            {
                Categories = await _categoryRepository.GetAllCategoriesAsync()
            };
            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([Bind("Name, Description, ImageUrl,Price,CreatedAt,Color,Width,Height,Depth,Weight,Material,SelectedCategoryId")] ProductVM productVM)
        {
            if(ModelState.IsValid)
            {
                await _productRepository.CreateProductAsync(productVM);
                return RedirectToAction(nameof(Index));
            } else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if(product == null)
            {
                BadRequest();
            }
            return View(product);
        }
        public async Task<IActionResult> Details(int id)
        {
            var productCategories = await _productCategoryRepository.GetSimilarProductsByIdAsync(id);

            return View(productCategories);
        }
        [HttpPost, ActionName("EditProduct")]
        public async Task<IActionResult> EditProduct(int id, [Bind("Name, Description, ImageUrl,Price")] ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                bool isUpdated = await _productRepository.UpdateProductAsync(id, productVM);
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
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool productDeletion = await _productRepository.DeleteProductAsync(id);
            if(productDeletion)
                return RedirectToAction(nameof(Index));
            else 
                return BadRequest(); //temoprary
        }
    }
}
