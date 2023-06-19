using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Interfaces.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBasketOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateOrderAsync(Order order, int quantity, int productId, decimal price)
        {

            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = order.TotalAmount,
                PhoneNumber = order.PhoneNumber,
                Status = "Pending...",
                PostalCode = order.PostalCode,
                UserName = order.UserName,
                ShippingAddress = order.ShippingAddress,
                PaymentMethod = order.PaymentMethod,
                ProductId = productId,
            };
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            var productOrder = new ProductOrder
            {
                Quantity = quantity,
                ShippingAddress = order.ShippingAddress,
                IsShipped = false,
                UnitPrice = price,
                Subtotal = price + 0.5M,
                IsCancelled = false,
                CancellationReason = "",
                OrderId = newOrder.Id,
                ProductId = productId
            };
            await _context.ProductOrders.AddAsync(productOrder);
            await _context.SaveChangesAsync();
        }


        public Task DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id)!;
        }

        public async Task<bool> isOrderExistingAsync(int orderId)
        {
            return await _context.Orders.AnyAsync(x => x.Id == orderId);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
