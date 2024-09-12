using CS047_ASP.NET_CORE_4.Middleware;
using CS047_ASP.NET_CORE_4.Options;
using CS047_ASP.NET_CORE_4.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text;

IConfiguration _iconfiguration;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TestOptionsMiddleware>();

builder.Services.AddSingleton<ProductNames>();

builder.Services.AddOptions();
var testOption = builder.Services.Configure<TestOptions>(
    builder.Configuration.GetSection("TestOptions"));
var app = builder.Build();

app.UseMiddleware<TestOptionsMiddleware>();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Heloooooo");
    });

    endpoints.MapGet("/showoptions", async context =>
    {
        var testOptions = context.RequestServices.GetService<IOptions<TestOptions>>().Value;

        /*var configuration = context.RequestServices.GetService<IConfiguration>();
        var testOptions = configuration.GetSection("TestOptions").Get<TestOptions>();*/
        /*var opt_key1 = testOptions["opt_key1"];
        var k1 = testOptions.GetSection("opt_key2")["k1"];
        var k2 = testOptions.GetSection("opt_key2")["k2"];*/


        var stringBuilder = new StringBuilder();
        /*stringBuilder.Append("TESTOPTIONS\n");
        stringBuilder.Append($"opt_key1 = {opt_key1}\n");
        stringBuilder.Append($"TestOptions.opt_key2.k1 = {k1}\n");
        stringBuilder.Append($"TestOptions.opt_key2.k2 = {k2} \n");*/

        /*stringBuilder.Append("\nTESTOPTIONS\n");
        stringBuilder.Append($"opt_key1 = {testOptions.opt_key1}\n");
        stringBuilder.Append($"TestOptions.opt_key2.k1 = {testOptions.opt_key2.k1}\n");
        stringBuilder.Append($"TestOptions.opt_key2.k2 = {testOptions.opt_key2.k2} \n");

        context.Response.WriteAsync($"{stringBuilder.ToString()}");*/
    });
});


//app.MapGet("/", () => "Hello World!");

app.Run();
