namespace SmartPOS.Infrastructure;

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using SmartPOS.Contracts.Services;
using SmartPOS.Domain.Repositories;
using SmartPOS.Infrastructure.Logging;
using SmartPOS.Infrastructure.Persistence;
using SmartPOS.Infrastructure.Services;
using SmartPOS.Infrastructure.Settings;

/// <summary>
/// Extension methods that register the infrastructure layer services with the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>Registers persistence, settings, headless UI services, logging and feature modules with the service collection.</summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration used to configure logging.</param>
    /// <param name="userSettingsPath">The path of the file used to persist user-scoped settings.</param>
    /// <param name="featureAssemblies">The assemblies to scan for <see cref="IFeatureModule" /> implementations.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        string userSettingsPath,
        params Assembly[] featureAssemblies)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddSingleton<ISettingsService>(sp => new SettingsService(sp.GetRequiredService<ILogger<SettingsService>>(), userSettingsPath));
        services.AddSingleton<IThemeService, NullThemeService>();
        services.AddSingleton<ILanguageService, NullLanguageService>();

        var logger = SerilogConfigurator.CreateLogger(configuration);
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddProvider(new SerilogLoggerProvider(logger));
        });

        services.AddSingleton(logger);

        foreach (var assembly in featureAssemblies)
        {
            var moduleTypes = assembly.GetTypes()
                .Where(t => typeof(IFeatureModule).IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false });
            foreach (var moduleType in moduleTypes)
            {
                var module = (IFeatureModule)Activator.CreateInstance(moduleType)!;
                module.Register(services);
            }
        }

        return services;
    }
}
