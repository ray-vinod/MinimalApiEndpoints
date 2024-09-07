using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiEndpoints;

public interface IService
{
    void Services(IServiceCollection services);

}