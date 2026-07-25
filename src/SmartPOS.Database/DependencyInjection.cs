namespace SmartPOS.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Database.Providers;
using SmartPOS.Shared.Configuration;
using SmartPOS.Shared.Enums;

/// <summary>
/// Extension methods that register the database layer services with the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>Registers the <see cref="AppDbContext" /> using the supplied database options.</summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="options">The database options that describe the provider and connection string to use.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddDbContext<AppDbContext>(dbOptions =>
        {
            switch (options.Provider)
            {
                case DatabaseProvider.Sqlite:
                    SqliteDbContextFactory.Configure(dbOptions, options);
                    break;
                case DatabaseProvider.PostgreSql:
                    PostgreSqlDbContextFactory.Configure(dbOptions, options);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported database provider '{options.Provider}'.");
            }

            if (options.LogSql)
            {
                dbOptions.EnableSensitiveDataLogging();
            }
        });

        return services;
    }
}
