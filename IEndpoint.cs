using Microsoft.AspNetCore.Builder;

namespace MinimalApiEndpoints;

public interface IEndpoint
{
    void DefineEndpoints(WebApplication app);
}