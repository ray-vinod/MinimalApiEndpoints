using Microsoft.AspNetCore.Builder;

namespace MinimalApiEndpoints;

public static class EndpointExtention
{
    public static WebApplication UseEndpoints(this WebApplication app)
    {
        foreach (var endpointInstance in Domain.Scan<IEndpoint>())
        {
            endpointInstance.Endpoints(app);
        }

        return app;
    }
}