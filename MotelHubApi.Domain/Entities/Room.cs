using System;
namespace MotelHubApi;

public class Room : BaseEntity
{
	public string? Name { get; set; }
	public double Acreage { get; set; }
	public int? OwnerId { get; set; }
	public int AreaId { get; set; }

	public Area Area { get; set; } = new();
	public User? Owner { get; set; }
	public ICollection<User> Members { get; set; } = new HashSet<User>();
    public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();

    public Room()
	{
	}
}

