using MyRepoApps.Repository.Interface;

namespace MyRepoApps.Models.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryScoped<TRepoInterface, TRepoImplementation, TEntity, Tkey>(
            this IServiceCollection services)
            where TRepoInterface : class, IBaseRepository<TEntity, Tkey>
            where TRepoImplementation : class, TRepoInterface
            where TEntity : class
    {
        // Register implementasi utama
        services.AddScoped<TRepoInterface, TRepoImplementation>();

        // Register interface base ke implementasi utama (1 instance saja)
        services.AddScoped<IBaseRepository<TEntity, Tkey>>(sp => sp.GetRequiredService<TRepoInterface>());

        return services;
    }
}
