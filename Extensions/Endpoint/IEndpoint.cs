using Microsoft.AspNetCore.Builder;

namespace MinimalApiEndpoints;

public interface IEndpoint
{
    void Endpoints(WebApplication app);
}