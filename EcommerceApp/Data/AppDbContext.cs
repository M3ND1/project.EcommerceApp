using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //FK Order Product table
            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new {po.OrderId, po.ProductId});
            //many to many relationship
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);
            //FK Product Category table
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new {pc.ProductId, pc.CategoryId});
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
            //FK Users Reviews
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(au => au.Reviews)
                .HasForeignKey(r => r.UserId);
            //FK Users Orders
            modelBuilder.Entity<Order>()
                .HasOne(r => r.User)
                .WithMany(au => au.Orders)
                .HasForeignKey(r => r.UserId);
        }
    }
}
