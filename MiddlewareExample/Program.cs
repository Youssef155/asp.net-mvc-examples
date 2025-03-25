using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//app.UseMiddleware<MyCustomMiddleware>();
//app.UseMyExtensionMiddleware();
app.UseSecondCustomMiddleware();

// the app.Run method will not forward
// the request to the next middleware
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello");
//});

// the app.Use method takes 2 arguments the RequestDelegate
// makes the middleware able to call the next one
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("\nHello");
    await next(context);
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("\nHello again");
});

app.Run();
