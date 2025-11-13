using MyRepoApps.Models;

namespace MyRepoApps.Repository.Interface;

public interface IBaseRepository<T, Tkey> where T : class
{
    Task<T?> GetByIdAsync(Tkey id, CancellationToken cancellationToken);
    Task<int> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(Tkey entityId, CancellationToken cancellationToken);
}
