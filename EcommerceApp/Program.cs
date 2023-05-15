using EcommerceApp;
using EcommerceApp.Data;
using EcommerceApp.Interfaces.CategoryRepositories;
using EcommerceApp.Interfaces.ProductCatgeoryOrderRepositories;
using EcommerceApp.Interfaces.ProductRepositories;
using EcommerceApp.Interfaces.ReviewRepositories;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependency Injection
builder.Services.AddScoped<IProductCategoryOrderRepository, ProductCategoryOrderRepository>(); //for user
builder.Services.AddScoped<IProductRepository, ProductRepository>(); //TODO: admin panel in future
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // =||=
builder.Services.AddScoped<IReviewRepository, ReviewRepository>(); // =||=
//DbContexts
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString")));
builder.Services.AddDbContext<CommerceIdentity>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//AppUser
builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.Password.RequiredLength = 6;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CommerceIdentity>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<UserManager<AppUser>>();

builder.Services.AddScoped<SeedDb>();

builder.Services.AddControllersWithViews();

//===
var app = builder.Build();

await SeedData(app);
async Task SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using(var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider;
        var seedDb = service.GetRequiredService<SeedDb>();
        await seedDb.SeedDatabase();
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
