namespace MotelHubApi;

public class Photo : BaseEntity
{
    public int? UserId { get; set; }
    public int? RoomId { get; set; }
    public int? BillId { get; set; }
    public int? WorkOrderId { get; set; }
    public byte[]? Data { get; set; }
    public string? Url { get; set; }
    public User? User { get; set; }
    public Room? Room { get; set; }
    public Bill? Bill { get; set; }
    public WorkOrder? WorkOrder { get; set; }
}
