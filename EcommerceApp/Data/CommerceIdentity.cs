using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class CommerceIdentity : IdentityDbContext<AppUser>
    {
        public CommerceIdentity(DbContextOptions<CommerceIdentity> options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}