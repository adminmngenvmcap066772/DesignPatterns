using Microsoft.AspNetCore.Http;

namespace MiddlewareWebApp
{
    public class FirstDemoMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstDemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Do something before next middleware
            context.Response.Headers.Add("X-First-Middleware", "Called");
            await context.Response.WriteAsync("First Middleware Start\n");
            await _next(context);
            await context.Response.WriteAsync("First Middleware End\n");
        }
    }
}
