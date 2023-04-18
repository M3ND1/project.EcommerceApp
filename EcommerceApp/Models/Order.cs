using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime OrderAt { get; set; }
        public decimal Price { get; set; }
        public string ShippingAddress { get; set; }
        public bool IsShipped { get; set; }

        //Relations 
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public AppUser User { get; set; }
    }
}
