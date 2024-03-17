using Microsoft.AspNetCore.Routing;

namespace MinimalApiEndpoints;

public interface IEndpoint
{
    void Endpoints(IEndpointRouteBuilder app);
}