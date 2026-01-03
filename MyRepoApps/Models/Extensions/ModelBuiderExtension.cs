using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if (IsSubClassOfRawGeneric(typeof(BaseEntity), entityClr.ClrType))
            {
                var idProperty = entityClr.FindProperty(nameof(IBaseEntity.Id));
                if (idProperty != null && idProperty.ClrType == typeof(int))
                {
                    idProperty.ValueGenerated = ValueGenerated.OnAdd;
                    modelBuilder.Entity(entityClr.ClrType)
                        .Property(nameof(IBaseEntity.Id))
                        .UseIdentityColumn();
                }

                var isDeletedProperty = entityClr.GetProperty(nameof(IBaseEntity.IsDeleted));
                if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
                {
                    var param = Expression.Parameter(entityClr.ClrType);
                    var body = Expression.Equal(
                        Expression.Property(param, nameof(IBaseEntity.IsDeleted)),
                        Expression.Constant(false)
                    );
                    var lambda = Expression.Lambda(body, param);
                    modelBuilder.Entity(entityClr.ClrType).HasQueryFilter(lambda);
                }
            }

            var publicIdProperty = entityClr.FindProperty("PublicId");
            if (publicIdProperty != null && publicIdProperty.ClrType == typeof(Guid))
            {
                publicIdProperty.SetDefaultValueSql("NEWID()");
                publicIdProperty.ValueGenerated = ValueGenerated.OnAdd;
            }
        }
    }

    private static bool IsSubClassOfRawGeneric(Type generic, Type toCheck)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (cur == generic)
                return true;

            toCheck = toCheck.BaseType!;
        }

        return false;
    }

    public static void ApplyGlobalDeleteBehavior(this ModelBuilder modelBuilder, DeleteBehavior behavior)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var fk in entityType.GetForeignKeys())
            {
                fk.DeleteBehavior = behavior;
            }
        }
    }
}
