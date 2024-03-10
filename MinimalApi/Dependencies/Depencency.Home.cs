using RegisterServices;
using Services;

namespace Dependencies;

public partial class Depencency : IService
{
    public void AddServices(IServiceCollection services)
    {
        services.AddScoped<IHomeService, HomeService>();
    }
}
