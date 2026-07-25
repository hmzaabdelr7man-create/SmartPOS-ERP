namespace SmartPOS.Infrastructure.Persistence;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Common;
using SmartPOS.Domain.Repositories;

/// <summary>
/// An Entity Framework Core implementation of <see cref="IRepository{T}" />.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
public class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<T> _set;

    /// <summary>Initializes a new instance of the <see cref="Repository{T}" /> class.</summary>
    /// <param name="context">The database context used to access the entity set.</param>
    public Repository(DbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    /// <inheritdoc />
    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _set.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public IQueryable<T> Query() => _set.AsQueryable();

    /// <inheritdoc />
    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = predicate is null ? _set : _set.Where(predicate);
        return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _set.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _set.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public void Update(T entity) => _set.Update(entity);

    /// <inheritdoc />
    public void Remove(T entity) => _set.Remove(entity);

    /// <inheritdoc />
    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        var query = predicate is null ? _set : _set.Where(predicate);
        return await query.CountAsync(cancellationToken).ConfigureAwait(false);
    }
}
