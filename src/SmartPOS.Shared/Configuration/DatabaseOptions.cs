namespace SmartPOS.Shared.Configuration;

using SmartPOS.Shared.Enums;

/// <summary>
/// Contains the configuration options for the application database.
/// </summary>
public sealed class DatabaseOptions
{
    /// <summary>Gets the configuration section name used to bind these options.</summary>
    public const string SectionName = "Database";

    /// <summary>Gets or sets the database provider to use for persistence.</summary>
    public DatabaseProvider Provider { get; set; } = DatabaseProvider.Sqlite;

    /// <summary>Gets or sets the connection string used when the provider is SQLite.</summary>
    public string SqliteConnectionString { get; set; } = "Data Source=smartpos.db";

    /// <summary>Gets or sets the connection string used when the provider is PostgreSQL.</summary>
    public string PostgreSqlConnectionString { get; set; } = "Host=localhost;Database=smartpos;Username=postgres;Password=postgres";

    /// <summary>Gets or sets a value indicating whether the database schema should be migrated automatically on startup.</summary>
    public bool AutoMigrate { get; set; } = true;

    /// <summary>Gets or sets a value indicating whether executed SQL statements should be logged.</summary>
    public bool LogSql { get; set; } = false;
}
