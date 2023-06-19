using EcommerceApp.Interfaces.OrderRepositories;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Interfaces.ProductRepositories;
using EcommerceApp.Migrations;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository, UserManager<AppUser> userManager)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int quantity, int productId) 
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            var user = await _userManager.GetUserAsync(User); // Get the current user
            if (user != null)
            {
                var userId = user.Id;//validation have to be done here

                ViewBag.Quantity = quantity;
                ViewBag.Product = product;
                ViewBag.UserId = userId;
                ViewBag.User = user;
                return View();

            }
            return RedirectToAction("Login", "Account", new { area = "Identity", page = "/Account/Login" }); //TODO: change it to you are not logged in
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([Bind("UserName, ShippingAddress, PostalCode, PhoneNumber, PaymentMethod, UserId, User, Status")] Order order, int quantity, int productId, decimal price)
        {
            order.ProductId = productId;
            var user = await _userManager.GetUserAsync(User); // Get the current user

            order.User = user;
            order.UserId = user.Id;

            if (ModelState.IsValid)
            {
                await _orderRepository.CreateOrderAsync(order,quantity,productId,price);
                return RedirectToAction("Index", "Home");
            }
            return BadRequest();          
        }
        public async Task<IActionResult> Details(int id) 
        {
            if(await _orderRepository.isOrderExistingAsync(id))
            {
                var searchedOrder = _orderRepository.GetOrderAsync(id);
                return View(searchedOrder);
            } else
            {
                return NotFound();
            }
        }
    }
}
