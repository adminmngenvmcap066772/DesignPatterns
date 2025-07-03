using Microsoft.AspNetCore.Http;

namespace MiddlewareWebApp
{
    public class SecondDemoMiddleware
    {
        private readonly RequestDelegate _next;

        public SecondDemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Do something before next middleware
            context.Response.Headers.Add("X-Second-Middleware", "Called");
            await context.Response.WriteAsync("Second Middleware Start\n");
            await _next(context);
            await context.Response.WriteAsync("Second Middleware End\n");
        }
    }
}
