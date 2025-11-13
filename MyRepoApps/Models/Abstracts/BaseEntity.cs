using System.ComponentModel.DataAnnotations;

namespace MyRepoApps.Models.Abstract;

public interface IBaseEntity
{
    object Id { get; }
    DateTime CreatedAt { get; set; }
    DateTime? ModifiedAt { get; set; }
    public string CreatedBy { get; set; }

    string? ModifiedBy { get; set; }
    bool IsDeleted { get; set; }
}

public abstract class BaseEntity<TKey> : IBaseEntity
{
    [Key]
    public TKey Id { get; set; }
    object IBaseEntity.Id => this.Id!;
    public DateTime CreatedAt { get; set; } 
    [MaxLength(255)]
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    [MaxLength(255)]
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
