using Extentions.Common;
using Microsoft.AspNetCore.Builder;

namespace Extentions.Endpoint;

public static class EndpointExtention
{
    public static WebApplication UseEndpoints(this WebApplication app)
    {
        foreach (var endpointInstance in Scanner.Assemblies<IEndpoint>())
        {
            endpointInstance.Endpoints(app);
        }

        return app;
    }

    // Channing Extentions

    public static WebApplication UseSwaggerAuth(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static WebApplication UseCorsPolicy(this WebApplication app, string policyName)
    {
        app.UseCors(policyName);

        return app;
    }
}