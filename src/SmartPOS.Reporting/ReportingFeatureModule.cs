namespace SmartPOS.Reporting;

using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Infrastructure;
using SmartPOS.Application.Abstractions.Reporting;
using SmartPOS.Infrastructure;
using SmartPOS.Reporting.Rendering;

/// <summary>
/// Registers the reporting feature services with the dependency injection container.
/// </summary>
public class ReportingFeatureModule : IFeatureModule
{
    /// <inheritdoc />
    public void Register(IServiceCollection services)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        services.AddSingleton<IReportRenderer, QuestPdfReportRenderer>();
    }
}
