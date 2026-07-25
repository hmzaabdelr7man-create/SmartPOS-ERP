namespace SmartPOS.Infrastructure.Logging;

using System.Globalization;
using Microsoft.Extensions.Configuration;
using Serilog;
using ILogger = Serilog.ILogger;

/// <summary>
/// Creates a Serilog logger from the supplied application configuration.
/// </summary>
public static class SerilogConfigurator
{
    /// <summary>Creates a Serilog logger that reads its configuration from the supplied <see cref="IConfiguration" />.</summary>
    /// <param name="configuration">The application configuration containing the Serilog section.</param>
    /// <returns>A configured <see cref="Serilog.ILogger" />.</returns>
    public static ILogger CreateLogger(IConfiguration configuration)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
            .WriteTo.File("logs/smartpos-.log", rollingInterval: RollingInterval.Day, formatProvider: CultureInfo.InvariantCulture);

        return loggerConfiguration.CreateLogger();
    }
}
