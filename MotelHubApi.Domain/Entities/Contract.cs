namespace MotelHubApi;
/// <summary>
/// Contract can not be deleted
/// Contract can change customer and host but can not change room
/// </summary>
public class Contract : BaseEntity
{
    public string? Title { get; set; }
    public int? CustomerId { get; set; }
    public int? RoomId { get; set; }
    public decimal? Price { get; set; }
    public bool IsHostConfirmed { get; set; }
    public bool IsCustomerConfirmed { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set;}
    public DateTime? CancelDate { get; set; }
    public byte[]? CustomerSignature{ get; set; }

    public User? Customer { get; set; }
    public User? Host { get; set; }
    public Room? Room { get; set; }
    public List<Photo> Photos { get; set; } = new List<Photo>();
    public List<Bill> Bills { get; set; } = new List<Bill>();
}
