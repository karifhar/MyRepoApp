using Microsoft.EntityFrameworkCore;
using MyRepoApps.Models.Abstract;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;

namespace MyRepoApps.Models.Extensions;

public static class ModelBuiderExtension
{
    public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
    {
        var baseEntityType = typeof(BaseEntity);
        foreach (var entityClr in modelBuilder.Model.GetEntityTypes())
        {
            if(baseEntityType.IsAssignableFrom(entityClr.ClrType))
            {
                var idProperty = entityClr.FindProperty(nameof(BaseEntity.Id));
                if (idProperty != null && idProperty.ClrType == typeof(Guid))
                {
                    idProperty.SetDefaultValueSql("NEWSEQUENTIALID()");
                    idProperty.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                }

                var isDeletedProperty = entityClr.FindProperty(nameof(BaseEntity.IsDeleted));
                if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
                {
                    var param = Expression.Parameter(entityClr.ClrType);
                    var body = Expression.Equal(
                        Expression.Property(param, nameof(IDeletable.IsDeleted)),
                        Expression.Constant(false)
                    );
                    var lambda = Expression.Lambda(body, param);
                    modelBuilder.Entity(entityClr.ClrType).HasQueryFilter(lambda);
                }
            }
        }
    }
}
