using EcommerceApp.Interfaces.OrderRepositories;
using EcommerceApp.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            var orders = _orderRepository.GetAllOrders();
            return View(orders);
        }
        public IActionResult Create(int quantity, int productId) 
        {
            ViewBag.Quantity = quantity;
            ViewBag.ProductId = productId;
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
