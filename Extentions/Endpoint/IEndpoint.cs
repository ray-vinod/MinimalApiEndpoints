
using Microsoft.AspNetCore.Builder;

namespace Extentions.Endpoint;

public interface IEndpoint
{
    void Endpoints(WebApplication app);
}