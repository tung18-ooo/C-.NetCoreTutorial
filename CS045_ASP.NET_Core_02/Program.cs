using CS045_ASP.NET_Core_02.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SeconMiddleware>();

var app = builder.Build();

app.UseStaticFiles();
//app.UseMiddleware<FirstMiddleware>();
app.UseFirstMiddleware();              //dua vao pineline FirstMiddleware
//app.UseMiddleware<SeconMiddleware>();
app.UseSecondMiddleware();             //dua vao pineline SecondMiddleware

app.UseRouting();                      //EndpointRoutingMiddleware

app.UseEndpoints(endpoints =>
{
    //endpoint1
    endpoints.MapGet("/about.html", async (context) =>
    {
        await context.Response.WriteAsync("Trang Gioi thieu");
    });
    //endpoint2
    endpoints.MapGet("/sanpham.html", async (context) =>
    {
        await context.Response.WriteAsync("Trang san pham");
    });


});


app.Map("/admin", (app1) =>
{
    app1.UseRouting();
    app1.UseEndpoints((endpoints) =>
    {
        endpoints.MapGet("/user", async (context) =>
        {
            await context.Response.WriteAsync("User Page");
        });
        endpoints.MapGet("/product", async (context) =>
        {
            await context.Response.WriteAsync("Product Page");
        });
    });
    app1.Run(async (ct) =>
    {
        await ct.Response.WriteAsync("Admin Page");
    });
});

//m1
app.Run(async (ct) =>
{
    await ct.Response.WriteAsync("A$APPPP");
});
//app.MapGet("/", () => "Hello World!");

app.Run();


/*
 Http
pineline : - StaticFileMiddleware 
                - FirstMiddleware - SecondMiddleware - EndpointRoutingMiddleware - m1
 */