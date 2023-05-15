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
        public async Task<ViewResult> Index()
        {
            var allProductsCategories = await _repository.GetAllProductCategoriesOrders();
            //var viewModelList = new List<ProductCategoryOrderVM>();
            //foreach (var product in allProductsCategories)
            //{
            //    var productCategoryViewModel = new ProductCategoryOrderVM();
            //        productCategoryViewModel.Product = product.Product;
            //        productCategoryViewModel.Categories = product.Categories;
            //        productCategoryViewModel.Order = product.Order;
            //    viewModelList.Add(productCategoryViewModel);
            //}
            //ViewData["allProducts"] = viewModelList;
            return View(allProductsCategories);
            //bodyconetnt null in index.cshtml riiip
        }

    }
}
