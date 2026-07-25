namespace SmartPOS.Backup;

using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Abstractions.Backup;
using SmartPOS.Backup.Services;
using SmartPOS.Infrastructure;

/// <summary>
/// Registers the backup feature services with the dependency injection container.
/// </summary>
public class BackupFeatureModule : IFeatureModule
{
    /// <inheritdoc />
    public void Register(IServiceCollection services)
    {
        services.AddSingleton<IBackupService, FileBackupService>();
    }
}
