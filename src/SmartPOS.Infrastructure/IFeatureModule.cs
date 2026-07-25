namespace SmartPOS.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Defines a self-contained module that registers a group of related infrastructure services.
/// </summary>
public interface IFeatureModule
{
    /// <summary>Registers the services owned by the feature module with the supplied service collection.</summary>
    /// <param name="services">The service collection to configure.</param>
    void Register(IServiceCollection services);
}
