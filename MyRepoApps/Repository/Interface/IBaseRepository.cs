namespace MyRepoApps.Repository.Interface;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void UpdateAsync(T entity, CancellationToken cancellationToken);
    void DeleteAsync(T entity, CancellationToken cancellationToken);
}
