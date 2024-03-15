using Microsoft.Extensions.DependencyInjection;

namespace Extentions.Service;

public interface IService
{
    void Services(IServiceCollection services);

}