namespace MotelHubApi;

public class BasePhotoModel : BaseEntityModel
{
    public int? UserId { get; set; }
    public int? RoomId { get; set; }
    public int? AreaId { get; set; }
    public int? ContractId { get; set; }
    public int? MeterReadingId { get; set; }
    public byte[]? Data { get; set; }
    public string? Url { get; set; }
}
