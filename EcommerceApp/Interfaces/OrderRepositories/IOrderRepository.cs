using EcommerceApp.Models;

namespace EcommerceApp.Interfaces.OrderRepositories
{
    public interface IOrderRepository
    {
        public ICollection<Order> GetAllOrders();
        public Order GetOrder(int id);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int id);
        public void CreateOrder(Order order, int quantity, int productId, decimal price);
        public void CreateBasketOrder();
        public bool isOrderExisting(int orderId);

    }
}
