using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateBasketOrder()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order, int quantity, int productId, decimal price)
        {
            var newOrder = new Order
            {
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                ShippingAddress = order.ShippingAddress,
                PaymentMethod = order.PaymentMethod
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            //relation
            var UserOrder = new Models.ProductOrder
            {
                Quantity = quantity,
                ShippingAddress = order.ShippingAddress,
                IsShipped = false,
                UnitPrice = price,
                Subtotal = price+0.5M,
                IsCancelled = false,
                CancellationReason = "",
                OrderId = newOrder.Id,
                ProductId = productId
            };
            _context.ProductOrders.Add(UserOrder);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id)!;
        }

        public bool isOrderExisting(int orderId)
        {
            return _context.Orders.Any(x => x.Id == orderId);
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
