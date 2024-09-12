using CS046_ASP.NET_Core_03.mylib;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {

        var menu = HtmlHelper.MenuTop(
            HtmlHelper.DefaultMenuTopItems(), context.Request
            /*new object[]
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
            },context.Request*/
            );

        var html = HtmlHelper.HtmlDocument("Xinnn Chaooo", menu + /*"Hello World".HtmlTag("h1", "text-danger"*/ HtmlHelper.HtmlTrangchu());

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
        //await context.Response.WriteAsync("Request Info");

        var menu = HtmlHelper.MenuTop(
            HtmlHelper.DefaultMenuTopItems(), context.Request
            );

        var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div","container");

        var html = HtmlHelper.HtmlDocument("Thong tin request", menu + info);
        await context.Response.WriteAsync(html);
    });


    endpoints.MapGet("/Encoding", async context =>
    {
        await context.Response.WriteAsync("Encoding");
    });

    endpoints.MapGet("/Cookies/{*action}", async context =>
    {
        //await context.Response.WriteAsync("Cookies");
        var menu = HtmlHelper.MenuTop(
            HtmlHelper.DefaultMenuTopItems(), context.Request
            );

        var action = context.GetRouteValue("action")??"read";  //neu khong co gi se return null

        string message = "";

        if (action.ToString() == "write")
        {
            //ten, gia tri, thoi gian hieu luc
            var option = new CookieOptions()
            {
                Path = "/",
                Expires = DateTime.Now.AddDays(1)
            };
            context.Response.Cookies.Append("masanpham", "432",option);
            message = "Cookie duoc ghi";
        }
        else
        {
            var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
            message = string.Join("", listcokie).HtmlTag("ul");
        }

        var huongdan = "<a class=\"btn btn-danger\" href=\"/Cookies/read\">Doc Cookie</a><a class=\"btn btn-success\" href=\"/Cookies/write\">Ghi Cookie</a>";
        huongdan = huongdan.HtmlTag("div", "container mt-4");
        message = message.HtmlTag("div", "alert alert-danger");
        var html = HtmlHelper.HtmlDocument("Cookies: " + action, menu + huongdan + message);
        await context.Response.WriteAsync(html);
    });

    endpoints.MapGet("/Json", async context =>
    {
        var p = new
        {
            TenSp = "Dong ho",
            Gia = 500000,
            NgaySX = new DateTime(2022, 12, 31)
        };

        context.Response.ContentType = "application/json";

        var json = JsonConvert.SerializeObject(p);

        await context.Response.WriteAsync(json);

        //await context.Response.WriteAsync("Json");
    });

    /*endpoints.MapGet("/Form", async context =>
    {
        //await context.Response.WriteAsync("Form");
        var menu = HtmlHelper.MenuTop(
           HtmlHelper.DefaultMenuTopItems(), context.Request
           );

        var formhtmml = RequestProcess.ProcessForm(context.Request);
        
        var html = HtmlHelper.HtmlDocument("Test submit form html", menu + formhtmml);
        await context.Response.WriteAsync(html);
    });

    endpoints.MapPost("/Form", async context =>
    {
        //await context.Response.WriteAsync("Form");
        var menu = HtmlHelper.MenuTop(
           HtmlHelper.DefaultMenuTopItems(), context.Request
           );

        var formhtmml = RequestProcess.ProcessForm(context.Request);

        var html = HtmlHelper.HtmlDocument("Test submit form html", menu + formhtmml);
        await context.Response.WriteAsync(html);
    });*/

    endpoints.MapMethods("/Form", new string[] { "POST","GET"}, async context =>
    {
        //await context.Response.WriteAsync("Form");
        var menu = HtmlHelper.MenuTop(
           HtmlHelper.DefaultMenuTopItems(), context.Request
           );

        var formhtmml = RequestProcess.ProcessForm(context.Request);

        var html = HtmlHelper.HtmlDocument("Test submit form html", menu + formhtmml);
        await context.Response.WriteAsync(html);
    });


});

//app.MapGet("/", () => "Hello World!");

app.Run();
