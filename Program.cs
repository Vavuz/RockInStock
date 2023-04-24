using Microsoft.EntityFrameworkCore;
using RockInStock.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGuitarRepository, GuitarRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }); ;    // bringing in framework services that enable MVC in this app

builder.Services.AddRazorPages();
builder.Services.AddDbContext<RockInStockDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:RockInStockDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();    // looking for requests for static files: html, css, etc.
app.UseSession();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();    // contains info that user shouldn't see but that can help us developers

app.MapDefaultControllerRoute();    // needed to be able to navigate (route) to our pages (views), it is endpoint middleware
app.MapRazorPages();
DbInitialiser.Seed(app);
app.Run();
