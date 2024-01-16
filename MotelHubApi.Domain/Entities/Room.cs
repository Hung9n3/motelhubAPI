namespace MotelHubApi;

public class Room : BaseEntity
{
	public string? Name { get; set; }
	public double Acreage { get; set; }
	public int? OwnerId { get; set; }
	public int? AreaId { get; set; }

	public Area? Area { get; set; }
	public User? Owner { get; set; }
    public ICollection<UserRoom> UserRooms { get; set; } = new HashSet<UserRoom>();
    public ICollection<User> Members { get; set; } = new HashSet<User>();
    public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    public ICollection<MeterReading> MeterReadings { get; set; } = new HashSet<MeterReading>();
    public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();

    public Room()
	{
	}
}

