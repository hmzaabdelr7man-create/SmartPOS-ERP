namespace SmartPOS.Database.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartPOS.Domain.Common;

/// <summary>
/// Applies a global query filter that excludes soft deleted entities from all queries.
/// </summary>
public static class SoftDeleteConvention
{
    /// <summary>Applies the soft delete query filter to every entity that implements <see cref="ISoftDeletable" />.</summary>
    /// <param name="modelBuilder">The model builder used to shape the entity model.</param>
    public static void Apply(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var property = System.Linq.Expressions.Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted));
                var falseConstant = System.Linq.Expressions.Expression.Constant(false);
                var filter = System.Linq.Expressions.Expression.Lambda(
                    System.Linq.Expressions.Expression.Equal(property, falseConstant),
                    parameter);

                entityType.SetQueryFilter(filter);
            }
        }
    }
}
