using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecondCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public SecondCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("fName") &&
                httpContext.Request.Query.ContainsKey("lName"))
            { 
                string fullName = httpContext.Request.Query["fName"] + " " + 
                httpContext.Request.Query["lName"];
                await httpContext.Response.WriteAsync(fullName);
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecondCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecondCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecondCustomMiddleware>();
        }
    }
}
