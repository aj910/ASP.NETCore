var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", (HttpContext context) => {

//    //setting custom headers in HTTP response

//    context.Response.Headers["My-Header"] = "Hello ASP.NET";


//    context.Response.Headers["Content-Type"] = "text/html";
//    return "<h2>This is a text HTTP response</h2>";
//    // Accessing path and method using HTTPContext object with context
//    //string path = context.Request.Path;
//    //string method = context.Request.Method;
    

   
//});
// setting response for routes using HTTP status codes
app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    if (path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in Home page!!!");
    } else if (path == "/About")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in About page!!!");

    } else if (path == "/Products")
    {
        if (context.Request.Query.ContainsKey("id") && context.Request.Query.ContainsKey("name"))
        {
            string id = context.Request.Query["id"];
            string name = context.Request.Query["name"];
            await context.Response.WriteAsync("You have selected the product with ID " + id + " and name " + name);
            return;

        }
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("You are in Products page!!!");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("The page you are looking for is not found!!!");
    }
});
// starting the server 
app.Run();
