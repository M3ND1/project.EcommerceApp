using EcommerceApp.Interfaces.CategoryRepositories;
using EcommerceApp.Interfaces.ProductCategory;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Interfaces.ProductRepositories;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public HomeController(ILogger<HomeController> logger, IProductCategoryRepository productCategoryRepository)
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
        }

        public IActionResult Index()
        {
            
            var (categories, products) = _productCategoryRepository.GetAllProductCategories();
            var model = new ProductCategoryVM
            {
                Categories = categories,
                ProductCategories = products
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}