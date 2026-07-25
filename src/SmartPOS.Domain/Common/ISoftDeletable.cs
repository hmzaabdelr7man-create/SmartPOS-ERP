namespace SmartPOS.Domain.Common;

/// <summary>
/// Marks an entity as supporting soft deletion rather than physical removal.
/// </summary>
public interface ISoftDeletable
{
    /// <summary>Gets or sets a value indicating whether the entity has been soft deleted.</summary>
    bool IsDeleted { get; set; }

    /// <summary>Gets or sets the UTC date and time the entity was soft deleted, if applicable.</summary>
    DateTime? DeletedAtUtc { get; set; }
}
