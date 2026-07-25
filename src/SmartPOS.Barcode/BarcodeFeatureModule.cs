namespace SmartPOS.Barcode;

using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Abstractions.Barcode;
using SmartPOS.Barcode.Generators;
using SmartPOS.Infrastructure;

/// <summary>
/// Registers the barcode feature services with the dependency injection container.
/// </summary>
public class BarcodeFeatureModule : IFeatureModule
{
    /// <inheritdoc />
    public void Register(IServiceCollection services)
    {
        services.AddSingleton<IBarcodeGenerator, BarcodeGenerator>();
    }
}
