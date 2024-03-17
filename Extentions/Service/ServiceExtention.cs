using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MinimalApiEndpoints;

public static class ServiceExtention
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        foreach (var serviceInstance in Domain.Scan<IService>())
        {
            serviceInstance.Services(services);
        }

        return services;
    }

    // Channing Extentions
    public static IServiceCollection AddSwaggerAuth(this IServiceCollection services, string title, string version)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = version });

            options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
            {
                Description = "",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "Bearer",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });


        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string policy)
    {
        services.AddCors(p => p.AddPolicy(policy, options =>
        {
            options.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }));

        return services;
    }
}