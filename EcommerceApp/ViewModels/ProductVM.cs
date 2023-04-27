using EcommerceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public List<Category>? Categories{ get; set; }
        [Display(Name="Category")]
        public int SelectedCategoryId { get; set; }
    }
}
