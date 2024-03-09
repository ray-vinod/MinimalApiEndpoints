# Minimal Api Endpoints

## This is a simple minimal api endpoints registering package for .NET Minimal api project

### How to use this package

```code
public class HomeEndpoint : IEndpoint
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/home", () => "Hello World!");

        app.MapPost("/echo", (string message) => message);
    }
}
```

```code
public class Student : IEndpoint
{
    public void DefineEndpoints(WebApplication app)
    {
        var group = app.MapGroup("/student");

        group.MapGet("", Students);
    }


    public IResult Students()
    {
        var students = new List<string> { "Student 1", "Student 2", "Student 3" };

        return Results.Ok(students);
    }
}
```

### In Program.cs

```code
var builder = WebApplication.CreateBuilder(args);
{
    ...others code ...

    builder.Services.AddEndpoints();
}
var app = builder.Build();
{
    ... others code...

    app.UseEndpoints();

    app.Run();
}
```
