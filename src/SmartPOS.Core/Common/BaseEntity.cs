namespace SmartPOS.Core.Common;

/// <summary>
/// Represents the base entity from which all domain entities derive.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>Gets or sets the unique identifier of the entity.</summary>
    public Guid Id { get; set; }

    /// <summary>Gets or sets the UTC date and time the entity was created.</summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>Gets or sets the UTC date and time the entity was last updated.</summary>
    public DateTime UpdatedAtUtc { get; set; }
}
