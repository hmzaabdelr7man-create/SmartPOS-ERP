namespace SmartPOS.Domain.Repositories;

using SmartPOS.Core.Common;

/// <summary>
/// Coordinates unit of work semantics across multiple repositories and exposes transactional control.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>Gets the repository for the specified entity type.</summary>
    /// <typeparam name="T">The type of entity managed by the repository.</typeparam>
    /// <returns>An <see cref="IRepository{T}" /> instance.</returns>
    IRepository<T> Repository<T>()
        where T : BaseEntity;

    /// <summary>Persists all pending changes tracked by the unit of work.</summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>Begins a new database transaction.</summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous begin operation.</returns>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>Commits the active database transaction.</summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous commit operation.</returns>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>Rolls back the active database transaction.</summary>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous rollback operation.</returns>
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
