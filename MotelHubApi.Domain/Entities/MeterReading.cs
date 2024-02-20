namespace MotelHubApi;

public class MeterReading : BaseEntity
{
	public string? Title { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
	public double? LastMonth { get; set; }
	public double? ThisMonth { get; set; }
	public MeterReadingType Type { get; set; }
	public int? OwnerId { get; set; }
	public string? OwnerPhone { get; set; }
	public string? OwnerName { get; set; }
	public int? RoomId { get; set; }
	public decimal? Price { get; set; }

	public User? Owner { get; set; }
	public Room? Room { get; set; }
    public List<Photo> Photos { get; set; } = new List<Photo>();

    public MeterReading()
	{
	}
}

