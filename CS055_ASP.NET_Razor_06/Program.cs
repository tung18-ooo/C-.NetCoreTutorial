using CS055_ASP.NET_Razor_06.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ProductService>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


/*
 * PageModel, ModelBinding
 * dotnet new page
 * - ProductPage
 * dotnet new page -n ProductPage -o Pages -na CS055_ASP.NET_Razor_06.Pages
 * 
 * 
 * Model Binding: lien ket du lieu
 * Du lieu gui den: (key, value)
 * Nguon:
 * - Form (post): HttpRequest.Form["key"]
 * - Query (html - get): HttpRequest.Query["key"]
 * -  Header: HttpRequest.Header["key"]
 * - Route data: HttpRequest.RouteValues["key"]
 * - Upload
 * - Body
 * Doc du lieu
 * - HttpRequest (Controller, PageModel, View)
 * */