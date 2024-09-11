

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        var menu = HtmlHelper.MenuTop(
            new object[]
            {
                new
                {
                    url = "/abc",
                    label = "Menu Abc"
                },
                new
                {
                    url = "/xyz",
                    label = "Menu xyz"
                }
            },context.Request
            );

        var html = HtmlHelper.HtmlDocument("Xinnn Chaooo", menu + "Hello World".HtmlTag("h1", "text-danger"));

        //await context.Response.WriteAsync("Hello World".HtmlTag("h1","text-danger"));
        await context.Response.WriteAsync(html);
    });

    /*endpoints.MapGet("/", async context => {
        string menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
        string content = HtmlHelper.HtmlTrangchu();
        string html = HtmlHelper.HtmlDocument("Trang chủ", menu + content);
        await context.Response.WriteAsync(html);
    });*/

    endpoints.MapGet("/RequestInfo", async context =>
    {
        await context.Response.WriteAsync("Request Info");
    });


    endpoints.MapGet("/Encoding", async context =>
    {
        await context.Response.WriteAsync("Encoding");
    });

    endpoints.MapGet("/Cookies", async context =>
    {
        await context.Response.WriteAsync("Cookies");
    });

    endpoints.MapGet("/Json", async context =>
    {
        await context.Response.WriteAsync("Json");
    });

    endpoints.MapGet("/Form", async context =>
    {
        await context.Response.WriteAsync("Form");
    });
});

//app.MapGet("/", () => "Hello World!");

app.Run();
