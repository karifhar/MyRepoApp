using MyRepoApps.Models;
using MyRepoApps.Repository.Interface;
using MyRepoApps.Services.Interface;

namespace MyRepoApps.Services;

public class RepositoryService(IMRepository _repositoryRepo) : IRepositoryService
{
    public async Task<int> AddRepositoryAsync(int userid, CancellationToken cancellationToken)
    {
        var newRepo = new MRepository
        {
            UserId = userid,
            ReposityName = "My Repo_" + Guid.NewGuid(),
            QuotaLimitBytes = 10737418240, // 10 GB
        };

        await _repositoryRepo.AddAsync(newRepo, cancellationToken);
        return 1;
    }
}
