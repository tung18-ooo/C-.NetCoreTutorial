namespace CS045_ASP.NET_Core_02.MiddleWare
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        //RequestDelegate ~ (HttpContext context) => {}
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //HttpContext di qua Middleware trong pipeline
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"URL: {context.Request.Path}");
            context.Items.Add("DataFirstMiddleware", $"<p>Url: {context.Request.Path}</p>");
            //await context.Response.WriteAsync($"<p>URL: {context.Request.Path}</p>");
            await _next(context);
        }
    }
}
