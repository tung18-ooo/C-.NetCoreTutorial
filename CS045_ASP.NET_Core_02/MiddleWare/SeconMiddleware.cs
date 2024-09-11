
namespace CS045_ASP.NET_Core_02.MiddleWare
{
    public class SeconMiddleware : IMiddleware
    {
        /**
         * URL: "/xxx.html"
         * - khong goi middleware phia sau
         * - ban kh dc truy cap
         * - Header - SecondMiddleware: Ban khong duoc truy cap
         * URL: != "/xxx.html"
         * - Header - SecondMiddleware: Ban duoc truy cap
         * - Chuyen httpcontext cho Middleware phai sau
        */
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                var data1stMiddle = context.Items["DataFirstMiddleware"];
                if (data1stMiddle != null)
                {
                    await context.Response.WriteAsync((string)data1stMiddle);
                    await context.Response.WriteAsync("Ban khong duoc truy cap");
                }
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban duoc truy cap");
                var data1stMiddle = context.Items["DataFirstMiddleware"];
                if (data1stMiddle != null)
                {
                    await context.Response.WriteAsync((string)data1stMiddle);
                }
                    await next(context);
            }

        }
    }
}
