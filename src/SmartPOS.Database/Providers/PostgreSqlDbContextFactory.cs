namespace SmartPOS.Database.Providers;

using Microsoft.EntityFrameworkCore;
using SmartPOS.Core.Configuration;

/// <summary>
/// Configures the <see cref="AppDbContext" /> to use the PostgreSQL database provider.
/// </summary>
public static class PostgreSqlDbContextFactory
{
    /// <summary>Configures the supplied <see cref="DbContextOptionsBuilder" /> to use PostgreSQL.</summary>
    /// <param name="builder">The options builder to configure.</param>
    /// <param name="options">The database options containing the PostgreSQL connection string.</param>
    public static void Configure(DbContextOptionsBuilder builder, DatabaseOptions options)
    {
        builder.UseNpgsql(options.PostgreSqlConnectionString);
    }
}
