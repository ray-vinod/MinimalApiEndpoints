using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiEndpoints;

public static class EndpointExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        var endpoints = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(IEndpoint)) && !t.IsInterface);

        foreach (var endpoint in endpoints)
        {
            services.AddSingleton(typeof(IEndpoint), endpoint);
        }
    }

    public static void UseEndpoints(this WebApplication app)
    {
        var scope = app.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetServices<IEndpoint>();
        foreach (var endpoint in endpoints)
        {
            endpoint.Endpoints(app);
        }
    }
}
