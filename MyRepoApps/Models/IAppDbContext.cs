using Microsoft.EntityFrameworkCore;

namespace MyRepoApps.Models;

public interface IAppDbContext
{
    DbSet<MRepository> Repositories { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}