namespace EcommerceApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        //Relations
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
