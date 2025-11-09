namespace MyRepoApps.Services.Interface;

public interface IRepositoryService
{
    Task<int> AddRepositoryAsync(int userid, CancellationToken cancellationToken);
}
