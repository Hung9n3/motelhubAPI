using Microsoft.AspNetCore.Identity;

namespace MotelHubApi;

public class User : IdentityUser<int>
{
    public int? RoleId { get; set; }
    public int? RoomLiving { get; set; }
    public Room? Room { get; set; }
    public Role? Role { get; set; }
    public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
}