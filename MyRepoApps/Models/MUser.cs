using MyRepoApps.Models.Abstract;

namespace MyRepoApps.Models;

public class MUser : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool LookedOut { get; set; }

}
