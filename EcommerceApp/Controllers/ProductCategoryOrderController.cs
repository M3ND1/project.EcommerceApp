using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ProductCategoryOrderController : Controller
    {
        private readonly IProductCategoryOrderRepository _repository;
        public ProductCategoryOrderController(IProductCategoryOrderRepository repository, ILogger<HomeController> logger)
        {
            _repository = repository;

        }
        public async Task<IActionResult> Index()
        {
            var allProductsCategories = await _repository.GetAllProductCategoriesOrdersAsync();
            return View(allProductsCategories);
        }

    }
}
