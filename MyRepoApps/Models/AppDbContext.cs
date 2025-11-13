using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyRepoApps.Models.Abstract;
using MyRepoApps.Models.Extensions;
using System;
using System.Security.Cryptography;

namespace MyRepoApps.Models;

public interface IAppDbContext
{
    DbSet<MRepository> Repositories { get; set; }
    DbSet<MUser> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<MRepository> Repositories { get; set; }
    public DbSet<MUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }

    public void ApplyChageTrackers()
    {
        var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";
        foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyChageTrackers();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ApplyChageTrackers();
        return base.SaveChanges();
    }
}
