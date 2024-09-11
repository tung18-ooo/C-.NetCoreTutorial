namespace CS045_ASP.NET_Core_02.MiddleWare
{
    public static class UseFirstMiddlewareMethod
    {
        public static void UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void UseSecondMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SeconMiddleware>();
        }
    }
}
