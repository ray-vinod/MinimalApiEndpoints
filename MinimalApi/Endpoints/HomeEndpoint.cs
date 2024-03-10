using MinimalApiEndpoints;
using Services;

namespace Endpoints;

public class HomeEndpoint : IEndpoint
{
    public void Endpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/home", () => "Welcome to the Minimal API!");
        app.MapGet("/message", Message);
    }

    public IResult Message(IHomeService service)
    {
        var message = service.Message();
        return Results.Ok(message);
    }
}