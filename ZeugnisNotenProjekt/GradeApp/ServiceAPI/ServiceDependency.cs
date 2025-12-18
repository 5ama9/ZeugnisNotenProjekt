using DataAccessAPI;
using DataAccessAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceAPI.Interfaces;
using ServiceAPI.Services;

namespace ServiceAPI;

/// <summary>
/// Provides a convenience extension method for registering the application's logic
/// and data access layer services together.
/// </summary>
public static class ServiceDependency
{
    /// <summary>
    /// Registers the application's business logic services and their 
    /// required data access dependencies into the dependency injection container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    public static void AddLogicServices(this IServiceCollection services, IConfiguration config)
    {
        // First, register the data access layer that the logic services depend on.
        services.AddDataAccess(config);

        // Next, register the logic layer services.
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
