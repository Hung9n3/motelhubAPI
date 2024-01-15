namespace MotelHubApi;
/// <summary>
/// Contract can not be deleted
/// Contract can change customer and host but can not change room
/// </summary>
public class Contract : BaseEntity
{
    public string? Title { get; set; }
    public int? CustomerId { get; set; }
    public int? HostId { get; set; }
    public int? RoomId { get; set; }
    public string? RoomName { get; set; }
    public string? HostName { get; set; }
    public string? HostPhone { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? RoomAddress { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set;}
    public DateTime? CancelDate { get; set; }

    public User? Customer { get; set; }
    public User? Host { get; set; }
    public Room? Room { get; set; }
    public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
}
