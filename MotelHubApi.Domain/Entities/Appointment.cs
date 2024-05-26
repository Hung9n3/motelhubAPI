namespace MotelHubApi;
public class Appointment : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public DateTime? DateTime { get; set; }
    public int? Duration { get; set; }
    public int? RoomId { get; set; }
    public int? CustomerId { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsCancel { get; set; }
    public Room? Room { get; set; }
    public User? Customer { get; set; }
}
