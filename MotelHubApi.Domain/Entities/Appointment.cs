namespace MotelHubApi;
public class Appointment : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public DateTime? DateTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public int? RoomId { get; set; }
    public int? HostId { get; set; }
    public int? CustomerId { get; set; }

    public Room? Room { get; set; }
    public User? Host { get; set; }
    public User? Customer { get; set; }
}
