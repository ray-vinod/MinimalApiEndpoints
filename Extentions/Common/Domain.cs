namespace Extentions.Common;

public class Domain
{
    public static IEnumerable<TInterface> Scan<TInterface>()
    {
        var serviceEndpoints = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(TInterface).IsAssignableFrom(type) && !type.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<TInterface>();

        return serviceEndpoints;
    }
}