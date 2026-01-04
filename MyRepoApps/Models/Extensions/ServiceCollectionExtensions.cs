using MyRepoApps.Models.Abstract;
using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Models.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryScoped<TRepoInterface, TRepoImplementation, TEntity>(
            this IServiceCollection services)
            where TRepoInterface : class, IBaseRepository<TEntity>
            where TRepoImplementation : class, TRepoInterface
            where TEntity : class, IBaseEntity
    {
        // Register implementasi utama
        services.AddScoped<TRepoInterface, TRepoImplementation>();

        // Register interface base ke implementasi utama (1 instance saja)
        services.AddScoped<IBaseRepository<TEntity>>(sp => sp.GetRequiredService<TRepoInterface>());

        return services;
    }
}
