namespace SmartPOS.Database;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Database.Configuration;
using SmartPOS.Domain.Common;

/// <summary>
/// The Entity Framework Core database context that mediates between the domain entities and the configured database provider.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>Initializes a new instance of the <see cref="AppDbContext" /> class.</summary>
    /// <param name="options">The options describing how the context should be configured.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SoftDeleteConvention.Apply(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    /// <inheritdoc />
    public override int SaveChanges()
    {
        ApplyAuditRules();
        return base.SaveChanges();
    }

    /// <inheritdoc />
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditRules();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditRules()
    {
        var now = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAtUtc = now;
                    entry.Entity.UpdatedAtUtc = now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAtUtc = now;
                    break;
            }
        }

        foreach (var entry in ChangeTracker.Entries<ISoftDeletable>())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.DeletedAtUtc = now;
            }
        }
    }
}
