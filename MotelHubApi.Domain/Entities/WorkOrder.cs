namespace MotelHubApi;
/// <summary>
/// Bill can not deleted so it should has all needed info
/// </summary>
public class WorkOrder : BaseEntity
{
    public string? Title { get; set; }
    public int? RoomId { get; set; }
    public int? CreatorId { get; set; }
    public bool? IsCustomerPay { get; set; }
    public double? Price { get; set; }
    public bool? IsOpen { get; set; }

    public Room? Room { get; set; }
    public User? Creator { get; set; }
    public List<Photo> Photos { get; set; } = new List<Photo>();

}
