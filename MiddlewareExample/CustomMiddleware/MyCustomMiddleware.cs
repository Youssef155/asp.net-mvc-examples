
namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\ncustom middleware - start");
            await next(context);
            await context.Response.WriteAsync("\ncustom middleware - end");
        }
    }

    public static class MyCustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyExtensionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
