using System.ComponentModel.DataAnnotations;

namespace MyRepoApps.Models.Abstract;

public interface IBaseEntity
{
    int Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? ModifiedAt { get; set; }
    string CreatedBy { get; set; }
    string? ModifiedBy { get; set; }
    bool IsDeleted { get; set; }
}

public abstract class BaseEntity : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } 
    [MaxLength(255)]
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    [MaxLength(255)]
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
