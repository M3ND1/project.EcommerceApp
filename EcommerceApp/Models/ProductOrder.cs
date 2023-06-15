using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTimeOffset OrderAt { get; set; }
        public int Quantity { get; set; }
        public string ShippingAddress { get; set; }
        public bool IsShipped { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public bool IsCancelled { get; set; }
        public string CancellationReason { get; set; }

        // Relations
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
