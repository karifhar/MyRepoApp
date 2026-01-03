using MyRepoApps.Models;

namespace MyRepoApps.Repository.Interface;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid PublicId, CancellationToken cancellationToken);
    Task<int> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid entityId, CancellationToken cancellationToken);
}
