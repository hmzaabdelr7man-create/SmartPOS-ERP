namespace SmartPOS.Database.Providers;

using Microsoft.EntityFrameworkCore;
using SmartPOS.Core.Configuration;

/// <summary>
/// Configures the <see cref="AppDbContext" /> to use the SQLite database provider.
/// </summary>
public static class SqliteDbContextFactory
{
    /// <summary>Configures the supplied <see cref="DbContextOptionsBuilder" /> to use SQLite.</summary>
    /// <param name="builder">The options builder to configure.</param>
    /// <param name="options">The database options containing the SQLite connection string.</param>
    public static void Configure(DbContextOptionsBuilder builder, DatabaseOptions options)
    {
        builder.UseSqlite(options.SqliteConnectionString);
    }
}
