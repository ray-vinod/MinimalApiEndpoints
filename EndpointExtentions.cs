using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiEndpoints;

public static class EndpointExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var endpointTypes = assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var type in endpointTypes)
        {
            services.AddSingleton(typeof(IEndpoint), type);
        }
    }

    public static void UseEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetServices<IEndpoint>();
        foreach (var endpoint in endpoints)
        {
            endpoint.DefineEndpoints(app);
        }
    }
}
