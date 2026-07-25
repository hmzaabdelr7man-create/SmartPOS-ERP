namespace SmartPOS.Application.Common.Exceptions;

/// <summary>
/// The exception that is thrown when a requested entity cannot be found.
/// </summary>
public class NotFoundException : ApplicationException
{
    /// <summary>Initializes a new instance of the <see cref="NotFoundException" /> class.</summary>
    /// <param name="entityName">The name of the entity type that was not found.</param>
    /// <param name="key">The key that was used to locate the entity.</param>
    public NotFoundException(string entityName, object key)
        : base($"Entity \"{entityName}\" ({key}) was not found.")
    {
        EntityName = entityName;
        Key = key;
    }

    /// <summary>Gets the name of the entity type that was not found.</summary>
    public string EntityName { get; }

    /// <summary>Gets the key that was used to locate the entity.</summary>
    public object Key { get; }
}
