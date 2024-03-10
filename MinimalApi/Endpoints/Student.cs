using MinimalApiEndpoints;

namespace Endpoints;

public class Student : IEndpoint
{
    public void Endpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/students", Students);
    }

    public IResult Students()
    {
        var students = new List<string> { "Student 1", "Student 2", "Student 3" };

        return Results.Ok(students);
    }
}