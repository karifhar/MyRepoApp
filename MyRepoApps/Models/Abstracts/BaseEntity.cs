using System.ComponentModel.DataAnnotations;

namespace MyRepoApps.Models.Abstract;

public interface IHasKey
{
    Guid Id { get; set; }
}

public interface IModifiable
{
    DateTime? ModifiedAt { get; set; }
    string? ModifiedBy { get; set; }
}

public interface IDeletable
{
    bool IsDeleted { get; set; }
}
public abstract class BaseEntity : IHasKey, IModifiable, IDeletable
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } 
    [MaxLength(255)]
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    [MaxLength(255)]
    public string? ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
