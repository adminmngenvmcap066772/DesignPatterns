using Microsoft.AspNetCore.Builder;

namespace MiddlewareWebApp
{
    public static class DemoMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstDemoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstDemoMiddleware>();
        }
        public static IApplicationBuilder UseSecondDemoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecondDemoMiddleware>();
        }
    }
}
