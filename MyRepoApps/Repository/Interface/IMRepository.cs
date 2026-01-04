using MyRepoApps.Models;

namespace MyRepoApps.Repository.Interface;

public interface IMRepository
{
   Task<MRepository?> GetRepositoryWithDetailAsync(int id, CancellationToken cancellationToken);
}
