using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            //global 
            List<Product> products = new List<Product>();
            var user = new AppUser();
            //Categories
            if (!_context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category { Name = "Electronics", ProductCategories = new List<ProductCategory>() }, //Id = 1
                    new Category { Name = "Home Appliances", ProductCategories = new List<ProductCategory>() },
                    new Category { Name = "Clothing", ProductCategories = new List<ProductCategory>() },//3
                    new Category { Name = "Automotive", ProductCategories = new List<ProductCategory>() },//4
                    new Category { Name = "Health", ProductCategories = new List<ProductCategory>() },
                    new Category { Name = "Movies", ProductCategories = new List<ProductCategory>() }, // Id = 6
                    new Category { Name = "Books", ProductCategories = new List<ProductCategory>() },
                    new Category { Name = "Sports", ProductCategories = new List<ProductCategory>() },
                    new Category { Name = "Gaming", ProductCategories = new List<ProductCategory>() } //Id = 9
                };
                _context.Categories.AddRange(categories);
                await _context.SaveChangesAsync();
            }
            //Products
            if (!_context.Products.Any())
            {
                products = new List<Product>()
                {
                    new Product() { //1
                        Name = "Iphone 8 Plus 64GB",
                        Description = "Smartphone with all the features you need",
                        ImageUrl="https://files.refurbed.com/ii/apple-iphone-8-plus-1639478234.jpg",
                        Price= 320.5m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(7) - TimeSpan.FromHours(2),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>(),
                    },
                    new Product() {
                        Name = "Washing Machine",
                        Description = "A powerful washing machine that cleans your clothes perfectly",
                        ImageUrl="https://media.croma.com/image/upload/v1670588931/Croma%20Assets/Large%20Appliances/Washers%20and%20Dryers/Images/240205_0_obspqa.png",
                        Price= 550.5m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(4) - TimeSpan.FromHours(13),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "Pug Squishy Toy",
                        Description = "Squishy fidget sensory stress pug dog toys for adults, teens and kids",
                        ImageUrl="https://ae01.alicdn.com/kf/H6b22da5b7e944e3bac5e1b544662ffa7V.jpg",
                        Price= 5,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(8) - TimeSpan.FromHours(2),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "T-Shirt",
                        Description = "A comfortable and stylish t-shirt",
                        ImageUrl = "https://demo.cs-cart.pl/images/detailed/1/t-4.jpg",
                        Price= 10,
                        CreatedAt = DateTime.UtcNow,
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "Sony PlayStation 5",
                        Description = "The latest gaming console from Sony with advanced graphics and processing power",
                        ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/24/2408146/Konsola-SONY-PlayStation-5-front.jpg",
                        Price= 499.99M,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(1) - TimeSpan.FromHours(4),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },                    
                    new Product() { //6
                        Name = "Ninja Air Fryer",
                        Description = "A kitchen appliance that cooks food with hot air instead of oil, for healthier meals",
                        ImageUrl = "https://cdn.shopify.com/s/files/1/0559/7881/9741/products/AirFryrer_Front_RT__CMYK_22_1800x1800.jpg?v=1631122755",
                        Price= 129.99M,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(3) - TimeSpan.FromHours(7),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {//7
                        Name = "Adidas Ultraboost 21 Running Shoes",
                        Description = "High-performance running shoes with superior comfort and energy return",
                        ImageUrl = "https://www.sportsdirect.com/images/imgzoom/21/21209118_xxl.jpg",
                        Price= 90M,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(2) - TimeSpan.FromHours(12),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {//8
                        Name = "Dell XPS 15 9510",
                        Description = "The most powerful XPS laptop we've ever built",
                        ImageUrl="https://www.mediaexpert.pl/media/cache/resolve/gallery/images/33/3349146/Laptop-DELL-XPS-15-9510-15.6-OLED-i7-11800H-16GB-SSD-1TB-GeForce-3050-Ti-Windows-11-Professional-skos-prawy.jpg",
                        Price= 1699m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(14) - TimeSpan.FromHours(9),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() { //9
                        Name = "Nintendo Switch",
                        Description = "Get the gaming system that lets you play the games you want, wherever you are, however you like",
                        ImageUrl="https://image.ceneostatic.pl/data/products/111261978/i-nintendo-switch-oled-white.jpg",
                        Price= 299.99m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(17) - TimeSpan.FromHours(2),
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
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
                    new ProductCategory() { Id = 4 , ProductId = 4, CategoryId = 3 },
                    new ProductCategory() { Id = 5 , ProductId = 5, CategoryId = 1 },
                    new ProductCategory() { Id = 6 , ProductId = 5, CategoryId = 9 },
                    new ProductCategory() { Id = 7 , ProductId = 6, CategoryId = 1 },
                    new ProductCategory() { Id = 8 , ProductId = 6, CategoryId = 2 },
                    new ProductCategory() { Id = 9 , ProductId = 7, CategoryId = 3 },
                    new ProductCategory() { Id = 10 , ProductId = 7, CategoryId = 8 },
                    new ProductCategory() { Id = 11 , ProductId = 8, CategoryId = 1 },
                    new ProductCategory() { Id = 12 , ProductId = 9, CategoryId = 9 },
                    new ProductCategory() { Id = 13 , ProductId = 9, CategoryId = 1 },
                };
                _context.ProductCategories.AddRange(productCategories);
                await _context.SaveChangesAsync();
            }
            //User creation
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!_context.AppUsers.Any())
            {
                //admin
                var admin = new AppUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FirstName = "Mendi",
                    LastName = "Here",
                    HomeAdress = "Przedzalniana",
                    IsAdmin = true
                };
                var password = "12345admin@WSX";
                var result = await _userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await _context.AppUsers.AddAsync(admin);
                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }

                //user
                user = new AppUser()
                {
                    UserName = "modroczek@gmail.com",
                    Email = "modroczek@gmail.com",
                    FirstName = "Saul",
                    LastName = "Goodman",
                    HomeAdress = "Albuquerque"
                };
                var user_password = "12345qaz@WSX";
                var user_result = await _userManager.CreateAsync(user, user_password);
                if (user_result.Succeeded)
                {
                    await _context.AppUsers.AddAsync(user);
                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
            //Orders
            if (!_context.Orders.Any())
            {
                try
                {
                    var user_relation = await _context.AppUsers.SingleOrDefaultAsync(u => u.Email == "modroczek@gmail.com");
                    var orders = new List<Order>
            {
                new Order
                {
                    UserId = user_relation.Id,
                    OrderAt = DateTime.Now.AddDays(-7),
                    Price = 100,
                    ShippingAddress = "123 Main St, Anytown USA",
                    IsShipped = true,
                    ProductOrders = new List<ProductOrder>(),
                },
                new Order
                {
                    UserId = user_relation.Id,
                    OrderAt = DateTime.Now.AddDays(-5),
                    Price = 50,
                    ShippingAddress = "456 Oak Ave, Anytown USA",
                    IsShipped = false,
                    ProductOrders = new List<ProductOrder>(),
                },
                new Order
                {
                    UserId = user_relation.Id,
                    OrderAt = DateTime.Now.AddDays(-5),
                    Price = 35,
                    ShippingAddress = "123 Elm St, Anytown USA",
                    IsShipped = true,
                    ProductOrders = new List<ProductOrder>(),
                },
                new Order
                {
                    UserId = user_relation.Id,
                    OrderAt = DateTime.Now.AddDays(-2),
                    Price = 75,
                    ShippingAddress = "789 Maple Ave, Anytown USA",
                    IsShipped = false,
                    ProductOrders = new List<ProductOrder>(),
                }
            };
                    await _context.Orders.AddRangeAsync(orders);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            if (!_context.ProductOrders.Any())
            {
                var productOrders = new List<ProductOrder>()
                {
                    new ProductOrder { Id = 1, Quantity = 2, ProductId = 3, OrderId = 1 },
                    new ProductOrder { Id = 2, Quantity = 1, ProductId = 4, OrderId = 2 },
                    new ProductOrder { Id = 3, Quantity = 4, ProductId = 2, OrderId = 3 },
                    new ProductOrder { Id = 4, Quantity = 3, ProductId = 1, OrderId = 4 },
                };
                await _context.ProductOrders.AddRangeAsync(productOrders);
                await _context.SaveChangesAsync();
            }
            //TODO: reviews seed??
        }
    }
}
