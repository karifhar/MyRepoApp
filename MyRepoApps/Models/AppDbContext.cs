using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyRepoApps.Models.Abstract;
using MyRepoApps.Models.Extensions;
using System;
using System.Security.Cryptography;

namespace MyRepoApps.Models;


public class AppDbContext : DbContext
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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MRepository>(entity =>
        {
            entity.HasOne(r => r.User)
                  .WithOne(u => u.Repository)
                  .HasForeignKey<MRepository>(r => r.UserId)   
                  .IsRequired();                                

            entity.HasIndex(r => r.UserId)
                  .IsUnique();                                 
        });

        modelBuilder.ApplyAllConfigurations();
    }

    public void ApplyChangeTrackers()
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
        ApplyChangeTrackers();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        ApplyChangeTrackers();
        return base.SaveChanges();
    }
}
