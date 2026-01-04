using Microsoft.EntityFrameworkCore;
using MyRepoApps.Models;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Repository;


public class MReposityRepo(IAppDbContext _db) : BaseRepository<MRepository>, IMRepository
{
    public Task<MRepository?> GetRepositoryWithDetailAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
