namespace SmartPOS.Domain.Common;

/// <summary>
/// Marks an entity as belonging to a specific tenant in a multi-tenant deployment.
/// </summary>
public interface IMultiTenant
{
    /// <summary>Gets or sets the identifier of the tenant that owns the entity.</summary>
    Guid TenantId { get; set; }
}
