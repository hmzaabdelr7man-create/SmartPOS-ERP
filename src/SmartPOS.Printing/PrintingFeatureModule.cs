namespace SmartPOS.Printing;

using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Abstractions.Printing;
using SmartPOS.Infrastructure;
using SmartPOS.Printing.Services;

/// <summary>
/// Registers the printing feature services with the dependency injection container.
/// </summary>
public class PrintingFeatureModule : IFeatureModule
{
    /// <inheritdoc />
    public void Register(IServiceCollection services)
    {
        services.AddSingleton<IPrintService, WindowsPrintService>();
    }
}
