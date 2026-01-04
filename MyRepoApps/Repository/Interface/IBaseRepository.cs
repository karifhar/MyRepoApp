using MyRepoApps.Models;
using MyRepoApps.Models.Abstract;

namespace MyRepoApps.Repository.Interface;

public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    Task<TEntity?> GetByIdAsync(Guid PublicId, CancellationToken cancellationToken);
    Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entityId, CancellationToken cancellationToken);
}