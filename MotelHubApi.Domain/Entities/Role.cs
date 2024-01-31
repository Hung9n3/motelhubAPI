using Microsoft.AspNetCore.Identity;

namespace MotelHubApi;

public class Role : IdentityRole<int>, IEntity
{
    public ICollection<User> Users { get; set; } = new HashSet<User>();
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }
}
