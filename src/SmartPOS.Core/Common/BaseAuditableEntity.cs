namespace SmartPOS.Core.Common;

/// <summary>
/// Represents an entity that carries audit metadata describing who created and last modified it.
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
    /// <summary>Gets or sets the identifier of the user who created the entity.</summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>Gets or sets the identifier of the user who last modified the entity.</summary>
    public Guid? UpdatedBy { get; set; }
}
