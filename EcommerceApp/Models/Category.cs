namespace EcommerceApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Relations
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
