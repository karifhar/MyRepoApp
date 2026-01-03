using MyRepoApps.Models.Abstract;

namespace MyRepoApps.Models;

public class Role : BaseEntity
{
    public Guid PublicId { get; set; }
    public string RoleName { get; set; }
}
