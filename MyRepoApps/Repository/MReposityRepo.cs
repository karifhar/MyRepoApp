using MyRepoApps.Models;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Repository;

public class MReposityRepo : IMRepository
{
    public Task AddAsync(MRepository entity, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
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
