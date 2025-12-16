using DataAccessAPI.Interfaces;
using DataAccessAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessAPI;

/// <summary>
/// Provides an extension method for registering data access layer services.
/// </summary>
public static class DataDependency
{
    /// <summary>
    /// Registers the DbContext and repositories for the data access layer.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The same <see cref="IServiceCollection"/> so that multiple calls can be chained.</returns>
    public static void AddDataAccess(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<GradesDb>(options =>
            options.UseMySql(connectionString,
                             ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IGradeRepository, GradeRepository>();
    }
}
