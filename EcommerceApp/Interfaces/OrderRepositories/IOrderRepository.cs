using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.OrderRepositories
{
    public interface IOrderRepository
    {
        public Task<ICollection<Order>> GetAllOrdersAsync();
        public Task<Order> GetOrderAsync(int id);
        public Task UpdateOrderAsync(Order order);
        public Task DeleteOrderAsync(int id);
        public Task CreateOrderAsync(Order order, int quantity, int productId, decimal price);
        public Task CreateBasketOrderAsync();
        public Task<bool> isOrderExistingAsync(int orderId);

    }
}
