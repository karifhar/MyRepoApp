using MyRepoApps.Models.Abstract;

namespace MyRepoApps.Models;

public class MRepository : BaseEntity
{
    public int UserId { get; set; }
    public string ReposityName { get; set; }
    public decimal QuotaLimitBytes { get; set; }
    public decimal UsedQuotaBytes { get; set; }
}
