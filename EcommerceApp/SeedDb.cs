using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApp
{
    public class SeedDb
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedDb(AppDbContext context, UserManager<AppUser> user, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = user;
            _roleManager = roleManager;
        }
        public async Task SeedDatabase()
        {
            //Categories
            if(!_context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category { Name = "Electronics" }, //Id = 1
                    new Category { Name = "Home Appliances" },
                    new Category { Name = "Clothing" },
                    new Category { Name = "Automotive" },
                    new Category { Name = "Health" },
                    new Category { Name = "Movies" } // Id = 6
                };
                _context.Categories.AddRange(categories);
                await _context.SaveChangesAsync();
            }
            //Products
            if (!_context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product() {
                        Name = "Iphone 8 Plus 64GB",
                        Description = "Smartphone with all the features you need",
                        ImageUrl="https://files.refurbed.com/ii/apple-iphone-8-plus-1639478234.jpg",
                        Price= 320.5m,
                        Quantity=1,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product() {
                        Name = "Washing Machine",
                        Description = "A powerful washing machine that cleans your clothes perfectly",
                        ImageUrl="https://media.croma.com/image/upload/v1670588931/Croma%20Assets/Large%20Appliances/Washers%20and%20Dryers/Images/240205_0_obspqa.png",
                        Price= 550.5m,
                        Quantity=1,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product() {
                        Name = "Pug Squishy Toy",
                        Description = "Squishy fidget sensory stress pug dog toys for adults, teens and kids",
                        ImageUrl="https://ae01.alicdn.com/kf/H6b22da5b7e944e3bac5e1b544662ffa7V.jpg",
                        Price= 5,
                        Quantity=7,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product() {
                        Name = "T-Shirt",
                        Description = "A comfortable and stylish t-shirt",
                        ImageUrl = "https://demo.cs-cart.pl/images/detailed/1/t-4.jpg",
                        Price= 10,
                        Quantity=20,
                        CreatedAt = DateTime.UtcNow
                    }
                };
                _context.Products.AddRange(products);
                await _context.SaveChangesAsync();
            }
            //Relations
            if (!_context.ProductCategories.Any())
            {
                var productCategories = new List<ProductCategory>()
                {
                    new ProductCategory() { Id = 1 , ProductId = 1, CategoryId = 1 },
                    new ProductCategory() { Id = 2 , ProductId = 2, CategoryId = 2 },
                    new ProductCategory() { Id = 3 , ProductId = 3, CategoryId = 5 },
                    new ProductCategory() { Id = 4 , ProductId = 4, CategoryId = 3 }
                };
                _context.ProductCategories.AddRange(productCategories);
                await _context.SaveChangesAsync();
            }
            //User creation
            if (!_userManager.Users.Any())
            {
                //admin
                var admin = new AppUser() {
                    UserName = "admin",
                    Email = "admin",
                    FirstName = "Mendi",
                    LastName = "Here",
                    HomeAdress = "Przedzalniana",
                    IsAdmin = true
                };
                var user = new AppUser()
                {
                    UserName = "modroczek@gmail.com",
                    Email = "modroczek@gmail.com",
                    FirstName = "Saul",
                    LastName = "Goodman",
                    HomeAdress = "Albuquerque"
                };
                IdentityResult user_result = await _userManager.CreateAsync(user, "password!23");
                if(user_result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                }
                IdentityResult result = _userManager.CreateAsync(admin, "admin123#").Result;
                if(result.Succeeded)
                {
                    _userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }
        }
    }
}
