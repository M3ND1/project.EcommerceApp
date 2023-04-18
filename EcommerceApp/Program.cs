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
    .AddEntityFrameworkStores<CommerceIdentity>()
    .AddDefaultTokenProviders();


builder.Services.AddControllersWithViews();
//dp injection

var app = builder.Build();

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
