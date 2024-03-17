using Microsoft.AspNetCore.Routing;

namespace MinimalApiEndpoints;

public static class EndpointExtention
{
    public static void UseEndpoints(this IEndpointRouteBuilder app)
    {
        foreach (var endpointInstance in Domain.Scan<IEndpoint>())
        {
            endpointInstance.Endpoints(app);
        }
    }
}