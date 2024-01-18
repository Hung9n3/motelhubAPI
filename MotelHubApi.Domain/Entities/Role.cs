using Microsoft.AspNetCore.Identity;

namespace MotelHubApi;

public class Role : IdentityRole<int>, IEntity
{
    public ICollection<User> Users { get; set; } = new HashSet<User>();
}
