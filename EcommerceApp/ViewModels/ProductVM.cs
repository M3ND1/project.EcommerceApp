using EcommerceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.ViewModels
{
    public class ProductVM //later leave only Name, Image, and realtions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        //public double ShoeLength????? 
        public double Weight { get; set; }
        public string Material { get; set; }
        public List<Category>? Categories{ get; set; }
        public int SelectedCategoryId { get; set; }
    }
}
