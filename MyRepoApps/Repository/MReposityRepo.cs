using Microsoft.EntityFrameworkCore;
using MyRepoApps.Models;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Repository;


public class MReposityRepo(IAppDbContext _db) : IMRepository
{

    public async Task<int> AddAsync(MRepository entity, CancellationToken cancellationToken)
    {
        await _db.Repositories.AddAsync(entity);
        return 1;
    }

    public async Task DeleteAsync(Guid entityId, CancellationToken cancellationToken)
    {
        var data =  await _db.Users.FirstOrDefaultAsync(x => x.Id == entityId, cancellationToken);

        if (data == null)
        {
            throw new Exception("Data is not found");
        }

        data.IsDeleted = true;
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<MRepository?> GetByIdAsync(Guid entityId, CancellationToken cancellationToken)
    {
        return await _db.Repositories.FirstOrDefaultAsync(x => x.Id == entityId);
    }

    public Task UpdateAsync(MRepository entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
