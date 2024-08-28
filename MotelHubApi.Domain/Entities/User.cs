using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MotelHubApi;

public class User : IdentityUser<int>, IEntity
{
    public string Fullname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }
    public int? RoleId { get; set; } = 1;

    public Role? Role { get; set; }
    public List<Room> CustomerRooms { get; set; } = new List<Room>();
    public List<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    public List<Contract> CustomerContracts { get; set; } = new List<Contract>();
    public List<Photo> Photos { get; set; } = new List<Photo>();
    public List<Area> Areas { get; set; } = new List<Area>();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    public User()
    {
        CreatedAt = DateTime.Now;
        ModifiedAt = DateTime.Now;
        IsActive = true;
    }
}