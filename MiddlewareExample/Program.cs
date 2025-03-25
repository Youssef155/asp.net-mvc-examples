var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// the app.Run method will not forward
// the request to the next middleware
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello");
//});


// the app.Use method takes 2 arguments the RequestDelegate
// makes the middleware able to call the next one
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello");
    await next(context);
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again");
});

app.Run();
