using Microsoft.EntityFrameworkCore;
using MyRepoApps.Models;
using MyRepoApps.Models.Abstract;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Repository;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    private


    protected BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(Guid PublicId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
