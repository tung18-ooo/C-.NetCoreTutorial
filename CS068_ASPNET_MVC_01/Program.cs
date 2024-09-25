using CS068_ASPNET_MVC_01.ExtendMethods;
using CS068_ASPNET_MVC_01.Models;
using CS068_ASPNET_MVC_01.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => {
    string connectString = builder.Configuration.GetConnectionString("AppMvcConnectString");
    options.UseSqlServer(connectString);
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    //{0} -> Ten Action
    //{1} -> Ten Controller
    //{2} -> Ten Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

});

//builder.Services.AddSingleton<ProductService>();                  
//builder.Services.AddSingleton<ProductService, ProductService>();
//builder.Services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
builder.Services.AddSingleton<PlanetService>();

//log
//builder.Services.AddTransient(typeof(ILogger<>),typeof(ILogger<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.AddStatusCodePage(); // Tuy bien Response loi : 400 - 599

app.UseRouting();

app.UseAuthentication(); //xac dinh danh tinh
app.UseAuthorization();  //xac thuc quyen truy cap

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapAreaControllerRoute(
        name: "product",
        pattern: "{controller}/{action=Index}/{id?}",
        areaName: "ProductManage"
        );

    // /sayhi
    endpoints.MapGet("/sayhi", async (context) =>
    {
        await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
    });

    /*endpoints.MapControllerRoute(
    *//*name: "firstroute",
    pattern: "start-here/{id?}", // or "start-here", neu khong co id thi id mac dinh = 3
    defaults: new { controller = "First"  , action = "ViewProduct", id = 3}*//*
    //or
    name: "default",
    pattern: "start-here/{controller=Home}/{action=Index}/{id?}"
);*/


    // voi  pattern: "{url}/{id?}", 
    //  - xemsanpham/1
    //  - fdfsdf/1
    //  - Home/1

    endpoints.MapControllerRoute(
    name: "first",
    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",  // xemsanpham/1
    defaults: new { controller = "First", action = "ViewProduct" }
/* constraints: new
 {
     //url = new StringRouteConstraint("xemsanpham"),
     //url = "xemsanpham"
     //
     //url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
     //id = new RangeRouteConstraint(2,4)  //chi nhan id = 2-4

 }*/
);

    //Controller khong co area
    endpoints.MapControllerRoute(

    name: "default",
    pattern: "start-here/{controller=Home}/{action=Index}/{id?}"
);
    endpoints.MapRazorPages();
});



app.Run();
