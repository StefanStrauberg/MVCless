using System.Data.SqlTypes;
using Mongo.Web;
using Mongo.Web.Services;
using Mongo.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IProductService, ProductService>();
SD.ProductApiBase = builder.Configuration["ServiceUrls:ProductAPI"];
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
