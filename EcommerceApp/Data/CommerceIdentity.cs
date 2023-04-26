using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class CommerceIdentity : IdentityDbContext<AppUser>
    {
        public CommerceIdentity(DbContextOptions<CommerceIdentity> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Category>();
            modelBuilder.Ignore<Order>();
            modelBuilder.Ignore<Product>();
            modelBuilder.Ignore<Review>();
            modelBuilder.Ignore<ProductCategory>();
            modelBuilder.Ignore<ProductOrder>();
        }
    }
}