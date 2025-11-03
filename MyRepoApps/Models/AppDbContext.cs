using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyRepoApps.Models.Abstract;
using System;
using System.Security.Cryptography;

namespace MyRepoApps.Models;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppDbContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MRepository> Repositories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public void ApplyChageTrackers()
    {
        var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            // You can add custom logic here before saving changes
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = username;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedBy = username;
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    break;
            }
        }
    }

    public override int SaveChanges()
    {
        ApplyChageTrackers();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyChageTrackers();
        return base.SaveChangesAsync(cancellationToken);
    }
}
