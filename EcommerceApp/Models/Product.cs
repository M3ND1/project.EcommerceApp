using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        //Relations
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
