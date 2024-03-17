using Microsoft.AspNetCore.Routing;

namespace Extentions.Endpoint;

public interface IEndpoint
{
    void Endpoints(IEndpointRouteBuilder app);
}