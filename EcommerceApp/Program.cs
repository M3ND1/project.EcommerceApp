using EcommerceApp;
using EcommerceApp.Data;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//identity
builder.Services.AddDbContext<CommerceIdentity>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString")));
//var connectionString = builder.Configuration.GetConnectionString("myConnString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})  
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CommerceIdentity>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<SeedDb>();


builder.Services.AddControllersWithViews();

//===
var app = builder.Build();
using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;
//var context = services.GetRequiredService<AppDbContext>();
//var userManager = services.GetRequiredService<UserManager<AppUser>>();
//var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

////seed db
//SeedDb.SeedDatabase(context,userManager,roleManager).Wait();

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
