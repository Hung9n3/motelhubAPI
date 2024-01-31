using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi;

public class User : IdentityUser<int>, IEntity
{
    public string Fullname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int? RoleId { get; set; }
    public Role? Role { get; set; }

    public ICollection<Room> OwnRooms { get; set; } = new HashSet<Room>();
    public ICollection<Room> LivingRooms { get; set; } = new HashSet<Room>();
    public ICollection<UserRoom> UserRooms { get; set; } = new HashSet<UserRoom>();
    public ICollection<Contract> HostContracts { get; set; } = new HashSet<Contract>();
    public ICollection<Contract> CustomerContracts { get; set; } = new HashSet<Contract>();
    public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    public ICollection<Area> Areas { get; set; } = new HashSet<Area>();
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }

    public User()
    {
        CreatedAt = DateTime.Now;
        ModifiedAt = DateTime.Now;
        IsActive = true;
    }
}