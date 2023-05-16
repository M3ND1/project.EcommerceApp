using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        //Relations
        public int ProductId { get; set; }
        public Product ?Product { get; set; }
        public AppUser ?User { get; set; }
    }
}
