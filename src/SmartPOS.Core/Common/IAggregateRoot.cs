namespace SmartPOS.Core.Common;

/// <summary>
/// Marks an entity as the root of an aggregate that can be persisted as a single transactional unit.
/// </summary>
public interface IAggregateRoot
{
    /// <summary>Gets the unique identifier of the aggregate root.</summary>
    Guid Id { get; }
}
