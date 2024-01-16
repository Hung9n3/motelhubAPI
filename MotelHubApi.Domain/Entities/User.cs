using Microsoft.AspNetCore.Identity;

namespace MotelHubApi;

public class User : IdentityUser<int>, IEntity
{
    public string Fullname { get; set; } = string.Empty;
    public int? RoleId { get; set; }
    public Role? Role { get; set; }

    public ICollection<Room> OwnRooms { get; set; } = new HashSet<Room>();
    public ICollection<Room> LivingRooms { get; set; } = new HashSet<Room>();
    public ICollection<UserRoom> UserRooms { get; set; } = new HashSet<UserRoom>();
    public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    public ICollection<Area> Areas { get; set; } = new HashSet<Area>();
}