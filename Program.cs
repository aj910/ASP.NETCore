var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) => {

    //setting custom headers in HTTP response

    context.Response.Headers["My-Header"] = "Hello ASP.NET";


    context.Response.Headers["Content-Type"] = "text/html";
    return "<h2>This is a text HTTP response</h2>";
    // Accessing path and method using HTTPContext object with context
    //string path = context.Request.Path;
    //string method = context.Request.Method;
    

   
} );

app.Run();
