using Microsoft.Extensions.Configuration;

namespace MinimalApiEndpoints;

public class Domain
{
    public static IEnumerable<TInterface> Scan<TInterface>()
    {
        var serviceEndpoints = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(TInterface).IsAssignableFrom(type) && !type.IsInterface)
            .Select(CreateInstance<TInterface>)
            .Cast<TInterface>();

        return serviceEndpoints;
    }

    private static TInterface CreateInstance<TInterface>(Type type)
    {
        try
        {
            return (TInterface)Activator.CreateInstance(type)!;
        }
        catch (MissingMethodException)
        {
            var configConstructor = type.GetConstructors()
           .FirstOrDefault(ctor => ctor.GetParameters().Any(p => p.ParameterType == typeof(IConfiguration)));

            if (configConstructor != null)
            {
                var configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .Build();

                return (TInterface)Activator.CreateInstance(type, configuration)!;
            }

            throw new InvalidOperationException($"{type.Name} has only allowed injection of IConfiguration.");
        }
    }
}