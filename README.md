# Minimal Api Endpoints

> This is a simple minimal api endpoints registering package for .NET Minimal api project

## How to use this

> In Program.cs

```code
var builder = WebApplication.CreateBuilder(args);
{
    ... others code...

    services.AddServices();

    ... others code...
}
```

```code
var app = builder.Build();
{
    ... others code...

    app.UseEndpoints();

    ... others code...
}
```

> for swaggerGen and cors complete with method channing

```code
var builder = WebApplication.CreateBuilder(args);
{
    ... others code...

    services.AddServices()
        .AddSwaggerAuth("App's Name", "1.0")
        .AddCorsPolicy("policyName");

    ... others code...
}
```

```code
var app = builder.Build();
{
    ... others code...
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("policyName");

    app.UseEndpoints();

    ... others code...
}
```

> In HomeEndpoint.cs

```code
public class HomeEndpoint : IEndpoint
{
    public void Endpoints(WebApplication app)
    {
        app.MapGet("/home", () => "Hello World!");

        app.MapPost("/echo", (string message) => message);
    }
}
```

> In Student.cs

```code
public class Student : IEndpoint
{
    public void Endpoints(WebApplication app)
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

```code
public class Student : IEndpoint
{
    public void Endpoints(WebApplication app)
    {
        var group = app.MapGroup("/student");

        group.MapGet("", (ISystemDateTime dateService)=>{
            var hh = dateService.UtcNow().Hour;
            var ss = dateService.UtcNow().Minute;
            var time = $"Current Time is : {hh}:{ss}";

            return time;
        }));
    }


    public void Services(IServiceCollection services)
    {
        services.AddScoped<ISystemDateTime,SystemDateTime>();
    }
}
```
