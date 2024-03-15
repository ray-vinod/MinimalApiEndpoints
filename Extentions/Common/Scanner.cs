namespace Extentions.Common;

public class Scanner
{
    public static IEnumerable<TInterface> Assemblies<TInterface>()
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