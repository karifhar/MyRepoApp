using MyRepoApps.Models;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Repository;

public class MReposityRepo(IAppDbContext _db) : IMRepository
{
    public async Task AddAsync(MRepository entity, CancellationToken cancellationToken)
    {
        await _db.Repositories.AddAsync(entity, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public void DeleteAsync(MRepository entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MRepository?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(MRepository entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
