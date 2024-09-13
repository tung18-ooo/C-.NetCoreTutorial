var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.RootDirectory = "/Pages"; //doi ten thu muc mac dinh luu tru razor page
    options.Conventions.AddPageRoute("/FirstPage", "/trangdautien.html"); //rewrite url hoac doi trong razor pages
});

builder.Services.Configure<RouteOptions>(routeOptions =>
{
    routeOptions.LowercaseUrls = true;
});

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    //FirstPage.cshtml URL = /FirstPage  /SecondPage  /ThirdPage


    endpoints.MapRazorPages();
   

});

//app.MapGet("/", () => "Hello World!");

app.Run();



/*
 * Razor page (.cshtml) = html + c#
 * Engine Razor -> bien dich cshtml -> Response
 * @page
 * @bien, @(bieu thuc), @phuongthuc
 * 
 * @{
 *      //code c#
 *      <html></html>  // nhung html
 * }
 * 
 * TagHelper -> html
 * @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
 * 
 * ViewData["mydata"]
 */