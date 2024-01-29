namespace MotelHubApi;

public class BasePhotoModel
{
    public int UserId { get; set; }
    public int RoomId { get; set; }
    public int AreaId { get; set; }
    public int ContractId { get; set; }
    public int MeterReadingId { get; set; }
    public byte[]? Data { get; set; }
    public string? Url { get; set; }
    public BaseUserModel? User { get; set; }
    public BaseRoomModel? Room { get; set; }
    public BaseAreaModel? Area { get; set; }
    public BaseContractModel? Contract { get; set; }
    public BaseMeterReadingModel? MeterReading { get; set; }
}
