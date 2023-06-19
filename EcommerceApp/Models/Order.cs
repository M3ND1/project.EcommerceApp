using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PhoneNumber { get; set; }
        public string? Status { get; set; }
        public string PostalCode{ get; set; }
        public string UserName { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; } //change to enum?
        //Relations 
        public int? ProductId { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
        public AppUser? User { get; set; }
    }
}
