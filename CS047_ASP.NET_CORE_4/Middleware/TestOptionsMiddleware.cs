
using CS047_ASP.NET_CORE_4.Options;
using CS047_ASP.NET_CORE_4.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text;

namespace CS047_ASP.NET_CORE_4.Middleware
{
    public class TestOptionsMiddleware : IMiddleware
    {
        TestOptions _testOptions {  get; set; }
        ProductNames _productNames;
        public TestOptionsMiddleware(IOptions<TestOptions> options,ProductNames product)
        {
            _testOptions = options.Value;
            _productNames = product;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Show options in TestOptionsMiddlware");
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("\nTESTOPTIONS\n");
            stringBuilder.Append($"opt_key1 = {_testOptions.opt_key1}\n");
            stringBuilder.Append($"TestOptions.opt_key2.k1 = {_testOptions.opt_key2.k1}\n");
            stringBuilder.Append($"TestOptions.opt_key2.k2 = {_testOptions.opt_key2.k2} \n");

            foreach(var prn in _productNames.GetNames())
            {
                stringBuilder.Append(prn + "\n");
            }

            await context.Response.WriteAsync(stringBuilder.ToString());

            await next(context);
        }
    }
}
