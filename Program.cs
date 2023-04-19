using RockInStock.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IGuitarRepository, MockGuitarRepository>();

builder.Services.AddControllersWithViews();    // bringing in framework services that enable MVC in this app

var app = builder.Build();

app.UseStaticFiles();    // looking for requests for static files: html, css, etc.

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();    // contains info that user shouldn't see but that can help us developers

app.MapDefaultControllerRoute();    // needed to be able to navigate (route) to our pages (views), it is endpoint middleware

app.Run();
