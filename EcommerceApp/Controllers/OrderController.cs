using EcommerceApp.Interfaces.OrderRepositories;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Interfaces.ProductRepositories;
using EcommerceApp.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var orders = _orderRepository.GetAllOrders();
            return View(orders);
        }
        public IActionResult Create(int quantity, int productId) 
        {
            var product = _productRepository.GetProductById(productId);
            ViewBag.Quantity = quantity;
            ViewBag.Product = product;
            return View();
        }
        public IActionResult Details(int id) 
        {
            if(_orderRepository.isOrderExisting(id))
            {
                var searchedOrder = _orderRepository.GetOrder(id);
                return View(searchedOrder);
            } else
            {
                return NotFound();
            }
        }
    }
}
