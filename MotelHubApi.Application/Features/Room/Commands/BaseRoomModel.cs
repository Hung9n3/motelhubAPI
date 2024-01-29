using System;
namespace MotelHubApi;

	public class BaseRoomModel 
	{
    public string? Name { get; set; }
    public double Acreage { get; set; }
    public int? OwnerId { get; set; }
    public int? AreaId { get; set; }

    public BaseAreaModel? Area { get; set; }
    public BaseUserModel? Owner { get; set; }
    public ICollection<UserRoom> UserRooms { get; set; } = new HashSet<UserRoom>();
    public ICollection<BaseUserModel> Members { get; set; } = new HashSet<BaseUserModel>();
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseMeterReadingModel> MeterReadings { get; set; } = new HashSet<BaseMeterReadingModel>();
    public ICollection<BaseContractModel> Contracts { get; set; } = new HashSet<BaseContractModel>();
}

