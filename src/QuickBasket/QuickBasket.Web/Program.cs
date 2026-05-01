using Microsoft.AspNetCore.Components.Web;
using QuickBasket.Web.Services.Implementations;
using QuickBasket.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//  MVC
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProductService, ProductService>(client => client.BaseAddress = new Uri("https://localhost:7025/api/"));


// Build app
var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   
app.UseRouting();
app.UseAuthorization();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();