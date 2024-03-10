using MinimalApiEndpoints;

namespace Endpoints;

public class NewEndpoints : IEndpoint
{
    public void Endpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/new", New);
    }

    public IResult New()
    {

        return Results.Ok("New Endpoint");
    }
}