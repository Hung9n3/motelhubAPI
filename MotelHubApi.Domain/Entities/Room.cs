namespace MotelHubApi;

public class Room : BaseEntity
{
	public string? Name { get; set; }
	public double Acreage { get; set; }
	public int? OwnerId { get; set; }
	public int? AreaId { get; set; }

	public Area? Area { get; set; }
	public User? Owner { get; set; }
    public List<UserRoom> UserRooms { get; set; } = new List<UserRoom>();
    public List<User> Members { get; set; } = new List<User>();
    public List<Photo> Photos { get; set; } = new List<Photo>();
    public List<MeterReading> MeterReadings { get; set; } = new List<MeterReading>();
    public List<Contract> Contracts { get; set; } = new List<Contract>();

    public Room()
	{
	}
}

