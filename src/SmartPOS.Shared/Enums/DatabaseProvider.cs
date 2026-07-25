namespace SmartPOS.Shared.Enums;

/// <summary>
/// Identifies the database engine that the application should use for persistence.
/// </summary>
public enum DatabaseProvider
{
    /// <summary>SQLite embedded database.</summary>
    Sqlite = 0,

    /// <summary>PostgreSQL server database.</summary>
    PostgreSql = 1,
}
