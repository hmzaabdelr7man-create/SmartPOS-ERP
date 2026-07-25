namespace SmartPOS.Domain.Repositories;

using System.Linq.Expressions;
using SmartPOS.Domain.Common;

/// <summary>
/// Provides generic read and write access to the entities of a given type.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
public interface IRepository<T>
    where T : BaseEntity
{
    /// <summary>Gets the entity with the specified identifier.</summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The entity if found; otherwise <see langword="null" />.</returns>
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Gets a queryable sequence representing the entities of the repository.</summary>
    /// <returns>An <see cref="IQueryable{T}" /> that can be used to compose queries.</returns>
    IQueryable<T> Query();

    /// <summary>Gets a list of entities matching the optional predicate.</summary>
    /// <param name="predicate">An optional filter predicate.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A read-only list of matching entities.</returns>
    Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);

    /// <summary>Adds a new entity to the repository.</summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous add operation.</returns>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>Adds a range of new entities to the repository.</summary>
    /// <param name="entities">The entities to add.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous add operation.</returns>
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>Marks the supplied entity as modified so that it will be updated on save.</summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>Removes the supplied entity from the repository.</summary>
    /// <param name="entity">The entity to remove.</param>
    void Remove(T entity);

    /// <summary>Gets the number of entities matching the optional predicate.</summary>
    /// <param name="predicate">An optional filter predicate.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The number of matching entities.</returns>
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
}
