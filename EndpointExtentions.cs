using Microsoft.AspNetCore.Routing;

namespace MinimalApiEndpoints;

public static class EndpointExtensions
{
    public static void UseEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var endpoint in endpoints)
        {
            if (Activator.CreateInstance(endpoint) is IEndpoint endpointInstance)
            {
                endpointInstance.Endpoints(app);
            }
        }
    }
}
