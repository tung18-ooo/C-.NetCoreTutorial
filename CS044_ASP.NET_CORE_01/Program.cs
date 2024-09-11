/*var options = new WebApplicationOptions
{
    WebRootPath = "smth"
};*/
    
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.UseStaticFiles(); // doc file trong wwwroot (neu co)

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async (ct) =>
    {
        await ct.Response.WriteAsync("HOME");
    });
    endpoints.MapGet("/about", async (ct) =>
    {
        await ct.Response.WriteAsync("ABOUT");
    });
    endpoints.MapGet("/contact", async (ct) =>
    {
        await ct.Response.WriteAsync("CONTACT");
    });
});

// StatusCodePages = 404 not found
app.UseStatusCodePages();
app.MapGet("/qq", () => "Hello wew!");
*//*app.MapGet("/", () => "Hello Worddddddld!");*//*

app.Run();

/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles(); // Đảm bảo rằng bạn có thể phục vụ các tệp tĩnh từ wwwroot

app.Run(async (context) =>
{
    string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>
                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                        <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                        <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                            <span class=""navbar-toggler-icon""></span>
                        </button>
                        <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                            </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
    ";
    await context.Response.WriteAsync(html);
});

app.Run();
*/