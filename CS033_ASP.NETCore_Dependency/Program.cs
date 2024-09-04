using CS033_ASP.NETCore_Dependency;
using static CS033_ASP.NETCore_Dependency.ProductServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
