namespace MotelHubApi;

public class Photo : BaseEntity
{
    public int? UserId { get; set; }
    public int? RoomId { get; set; }
    public int? AreaId { get; set; }
    public int? ContractId { get; set; }
    public int? MeterReadingId { get; set; }
    public byte[]? Data { get; set; }
    public string? Url { get; set; }
    public User? User { get; set; }
    public Room? Room { get; set; }
    public Area? Area { get; set; }
    public Contract? Contract { get; set; }
    public MeterReading? MeterReading { get; set; }
}
