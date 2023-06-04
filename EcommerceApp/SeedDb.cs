using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Drawing;
using static System.Net.WebRequestMethods;

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
                    new Category { Name = "Gaming", ProductCategories = new List<ProductCategory>() }, //Id = 9
                    new Category { Name = "Music", ProductCategories = new List<ProductCategory>() }, //Id = 10
                    new Category { Name = "Accessories", ProductCategories = new List<ProductCategory>() }, //Id = 11
                    new Category { Name = "Bedroom", ProductCategories = new List<ProductCategory>() }, //Id = 12
                    new Category { Name = "Kitchen", ProductCategories = new List<ProductCategory>() }, //Id = 13
                    new Category { Name = "Peripherals", ProductCategories = new List<ProductCategory>() } //Id = 13
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
                        ImageUrl = "https://files.refurbed.com/ii/apple-iphone-8-plus-1639478234.jpg",
                        Price = 320.5m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(7) - TimeSpan.FromHours(2),
                        Color = "Black",
                        Length = 2,
                        Width = 5,
                        Height = 8,
                        Weight = 0.5,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "Washing Machine",
                        Description = "A powerful washing machine that cleans your clothes perfectly",
                        ImageUrl = "https://media.croma.com/image/upload/v1670588931/Croma%20Assets/Large%20Appliances/Washers%20and%20Dryers/Images/240205_0_obspqa.png",
                        Price = 550.5m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(4) - TimeSpan.FromHours(13),
                        Color = "White",
                        Length = 60,
                        Width = 60,
                        Height = 85,
                        Weight = 50,
                        Material = "Metal",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "Pug Squishy Toy",
                        Description = "Squishy fidget sensory stress pug dog toys for adults, teens and kids",
                        ImageUrl = "https://ae01.alicdn.com/kf/H6b22da5b7e944e3bac5e1b544662ffa7V.jpg",
                        Price = 5,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(8) - TimeSpan.FromHours(2),
                        Color = "Grey", 
                        Length = 10,
                        Width = 10,
                        Height = 10,
                        Weight = 0.1,
                        Material = "Silicone",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "T-Shirt",
                        Description = "A comfortable and stylish t-shirt",
                        ImageUrl = "https://demo.cs-cart.pl/images/detailed/1/t-4.jpg",
                        Price = 10,
                        CreatedAt = DateTime.UtcNow,
                        Color = "Black",
                        Length = 2,
                        Width = 40,
                        Height = 60,
                        Weight = 0.3,
                        Material = "Cotton",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {
                        Name = "Sony PlayStation 5",
                        Description = "The latest gaming console from Sony with advanced graphics and processing power",
                        ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/24/2408146/Konsola-SONY-PlayStation-5-front.jpg",
                        Price= 499.99M,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(1) - TimeSpan.FromHours(4),
                        Color = "Black/White",
                        Length = 60,
                        Width = 60,
                        Height = 20,
                        Weight = 4.7,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },                    
                    new Product() { //6
                        Name = "Ninja Air Fryer",
                        Description = "A kitchen appliance that cooks food with hot air instead of oil, for healthier meals",
                        ImageUrl = "https://cdn.shopify.com/s/files/1/0559/7881/9741/products/AirFryrer_Front_RT__CMYK_22_1800x1800.jpg?v=1631122755",
                        Price= 129.99M,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(3) - TimeSpan.FromHours(7),
                        Color = "Black",
                        Length = 20,
                        Width = 17,
                        Height = 80,
                        Weight = 10.7,
                        Material = "Metal",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {//7
                        Name = "Adidas Ultraboost 21 Running Shoes",
                        Description = "High-performance running shoes with superior comfort and energy return",
                        ImageUrl = "https://www.sportsdirect.com/images/imgzoom/21/21209118_xxl.jpg",
                        Price= 90M,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(2) - TimeSpan.FromHours(12),
                        Color = "Dark Blue",
                        Length = 17, //TO DELETE LATER BECAUSE IT NOW CANNOT TAKE NULLS
                        Width = 5,
                        Height = 2,
                        Weight = 0.7,
                        Material = "Syntetic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() {//8
                        Name = "Dell XPS 15 9510",
                        Description = "The most powerful XPS laptop we've ever built",
                        ImageUrl="https://www.mediaexpert.pl/media/cache/resolve/gallery/images/33/3349146/Laptop-DELL-XPS-15-9510-15.6-OLED-i7-11800H-16GB-SSD-1TB-GeForce-3050-Ti-Windows-11-Professional-skos-prawy.jpg",
                        Price= 1699m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(14) - TimeSpan.FromHours(9),
                        Color = "Dark Grey",
                        Length = 13,
                        Width = 20,
                        Height = 10,
                        Weight = 3.7,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() { //9
                        Name = "Nintendo Switch",
                        Description = "Get the gaming system that lets you play the games you want, wherever you are, however you like",
                        ImageUrl="https://image.ceneostatic.pl/data/products/111261978/i-nintendo-switch-oled-white.jpg",
                        Price= 299.99m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(17) - TimeSpan.FromHours(2),
                        Color = "White",
                        Length = 2,
                        Width = 10,
                        Height = 5,
                        Weight = 3.5,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },
                    new Product() //10
                    {
                        Name = "T-shirt",
                        Description = "Casual t-shirt for everyday wear",
                        ImageUrl = "https://zajo.bwcdn.net/media/2022/06/1/4/sk-sven-t-shirt-ss-14441.jpg",
                        Price = 15m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(8),
                        Color = "Orange",
                        Length = 8,
                        Width = 8,
                        Height = 2,
                        Weight = 0.3,
                        Material = "Cotton",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //10 T-shirt orange
                    new Product()
                    {
                        Name = "Bluetooth Speaker",
                        Description = "Portable Bluetooth speaker for enjoying music on the go",
                        ImageUrl = "https://images.pexels.com/photos/1706694/pexels-photo-1706694.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 50m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(18),
                        Color = "Black",
                        Length = 6,
                        Width = 4,
                        Height = 8,
                        Weight = 0.5,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //11 Bluetooth Speaker
                    new Product() 
                    {
                        Name = "Gaming Chair",
                        Description = "Ergonomic gaming chair for enhanced comfort during long gaming sessions",
                        ImageUrl = "https://img.nitro-concepts.com/products/s300ex/gaming-chairs-s300ex-series.jpg",
                        Price = 250m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(40),
                        Color = "Black&Red",
                        Length = 24,
                        Width = 26,
                        Height = 48,
                        Weight = 25,
                        Material = "Leather",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //12 Gaming chair
                    new Product()
                    {
                        Name = "Airpods ",
                        Description = "True wireless earbuds for an immersive audio experience",
                        ImageUrl = "https://images.pexels.com/photos/3825517/pexels-photo-3825517.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 80m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(25),
                        Color = "Black",
                        Length = 2,
                        Width = 2,
                        Height = 2,
                        Weight = 0.1,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //13 AirPods
                    new Product()
                    {
                        Name = "Laptop Stand",
                        Description = "Adjustable laptop stand for better ergonomics",
                        ImageUrl = "https://images.pexels.com/photos/968631/pexels-photo-968631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 35m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(20),
                        Color = "Silver",
                        Length = 10,
                        Width = 8,
                        Height = 6,
                        Weight = 0.9,
                        Material = "Aluminum",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },//14 laptop stand
                    new Product()
                    {
                        Name = "Hoodie",
                        Description = "Comfortable hoodie for casual wear",
                        ImageUrl = "https://img01.ztat.net/article/spp-media-p1/2433f2b6c4253112934566fa5a365998/66f262c68685411bb1fae076a975d2a5.jpg?imwidth=762&filter=packshot",
                        Price = 40m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(15),
                        Color = "Black",
                        Length = 10,
                        Width = 10,
                        Height = 4,
                        Weight = 0.6,
                        Material = "Cotton",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },//15 black hoodie
                    new Product()
                    {
                        Name = "MacBook Pro",
                        Description = "Powerful laptop for professional use",
                        ImageUrl = "https://images.pexels.com/photos/2047905/pexels-photo-2047905.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 1899m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(30),
                        Color = "Space Gray",
                        Length = 12,
                        Width = 8,
                        Height = 0.6,
                        Weight = 1.4,
                        Material = "Aluminum",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //16 Macbook Pro
                    new Product()
                    {
                        Name = "Pillow",
                        Description = "Soft and comfortable pillow for a good night's sleep",
                        ImageUrl = "https://images.pexels.com/photos/994172/pexels-photo-994172.jpeg?auto=compress&cs=tinysrgb&w=1600",
                        Price = 25m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(10),
                        Color = "Colorful",
                        Length = 18,
                        Width = 18,
                        Height = 6,
                        Weight = 0.8,
                        Material = "Cotton",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //17 Pillow
                    new Product()
                    {
                        Name = "Apple Watch",
                        Description = "Multifunctional smartwatch for tracking activities and notifications",
                        ImageUrl = "https://images.pexels.com/photos/2861929/pexels-photo-2861929.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 150m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(12),
                        Color = "Silver",
                        Length = 2,
                        Width = 4,
                        Height = 1,
                        Weight = 0.2,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },//18 AppleWatch
                    new Product()
                    {
                        Name = "Sony Digital Camera",
                        Description = "High-quality digital camera for capturing stunning photos and videos",
                        ImageUrl = "https://images.pexels.com/photos/2929412/pexels-photo-2929412.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 500m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(25),
                        Color = "Black",
                        Length = 5,
                        Width = 4,
                        Height = 3,
                        Weight = 0.8,
                        Material = "Metal",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //19 Digital Camera
                    new Product()
                    {
                        Name = "Adidas Running Shoes",
                        Description = "Comfortable running shoes for athletes and fitness enthusiasts",
                        ImageUrl = "https://images.pexels.com/photos/2529148/pexels-photo-2529148.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 80m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(10),
                        Color = "White",
                        Length = 12,
                        Width = 4,
                        Height = 6,
                        Weight = 0.5,
                        Material = "Synthetic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //20 running shoes
                    new Product()
                    {
                        Name = "Xiaomi Portable Powerbank",
                        Description = "Compact power bank for charging devices on the go",
                        ImageUrl = "https://mi-store.pl/pol_pl_Powerbank-Xiaomi-33W-Power-Bank-10000mAh-Pocket-Edition-Pro-Ivory-2237_5.jpg",
                        Price = 30m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(6),
                        Color = "White",
                        Length = 4,
                        Width = 2,
                        Height = 0.5,
                        Weight = 0.1,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //21 Portable Powerbank
                    new Product()
                    {
                        Name = "Logitech Wireless Mouse",
                        Description = "Wireless mouse for smooth and precise cursor control",
                        ImageUrl = "https://images.pexels.com/photos/7091921/pexels-photo-7091921.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        Price = 25m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(9),
                        Color = "Black",
                        Length = 3,
                        Width = 2,
                        Height = 1,
                        Weight = 0.1,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //22 Black Mouse
                    new Product()
                    {
                        Name = "Fitness Tracker",
                        Description = "Wearable fitness tracker for monitoring health and activity levels",
                        ImageUrl = "https://m.media-amazon.com/images/I/51ehJixyuML._AC_UF1000,1000_QL80_.jpg",
                        Price = 60m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(14),
                        Color = "Purple",
                        Length = 2,
                        Width = 1,
                        Height = 0.5,
                        Weight = 0.05,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    }, //23 Fitness Tracker
                    new Product()
                    {
                        Name = "Stainless Steel Water Bottle",
                        Description = "Durable and leak-proof stainless steel water bottle for hydration",
                        ImageUrl = "https://m.media-amazon.com/images/I/71wFyZlg58L.jpg",
                        Price = 20m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(4),
                        Color = "Silver",
                        Length = 3,
                        Width = 3,
                        Height = 9,
                        Weight = 0.4,
                        Material = "Stainless Steel",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    },//24 Stainless water botttle
                    new Product()
                    {
                        Name = "External Hard Drive",
                        Description = "High-capacity external hard drive for storing and backing up data",
                        ImageUrl = "https://m.media-amazon.com/images/I/81tjLksKixL._AC_UF1000,1000_QL80_.jpg",
                        Price = 100m,
                        CreatedAt = DateTime.UtcNow - TimeSpan.FromDays(12),
                        Color = "Black",
                        Length = 5,
                        Width = 3,
                        Height = 1,
                        Weight = 0.2,
                        Material = "Plastic",
                        ProductCategories = new List<ProductCategory>(),
                        ProductOrders = new List<ProductOrder>()
                    } //25 External Hard Drive

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
                    new ProductCategory() { Id = 14 , ProductId = 10, CategoryId = 3 },
                    new ProductCategory() { Id = 15 , ProductId = 11, CategoryId = 1 },
                    new ProductCategory() { Id = 16 , ProductId = 12, CategoryId = 9 },
                    new ProductCategory() { Id = 17 , ProductId = 13, CategoryId = 10 },
                    new ProductCategory() { Id = 18 , ProductId = 14, CategoryId = 11 },
                    new ProductCategory() { Id = 19 , ProductId = 15, CategoryId = 3 },
                    new ProductCategory() { Id = 20 , ProductId = 16, CategoryId = 1 },
                    new ProductCategory() { Id = 21 , ProductId = 17, CategoryId = 12 },
                    new ProductCategory() { Id = 22 , ProductId = 18, CategoryId = 1 },
                    new ProductCategory() { Id = 23 , ProductId = 19, CategoryId = 1 },
                    new ProductCategory() { Id = 24 , ProductId = 20, CategoryId = 3 },
                    new ProductCategory() { Id = 25 , ProductId = 21, CategoryId = 1 },
                    new ProductCategory() { Id = 26 , ProductId = 22, CategoryId = 1 },
                    new ProductCategory() { Id = 27 , ProductId = 23, CategoryId = 5 },
                    new ProductCategory() { Id = 28 , ProductId = 24, CategoryId = 13 },
                    new ProductCategory() { Id = 29 , ProductId = 25, CategoryId = 14 },
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
