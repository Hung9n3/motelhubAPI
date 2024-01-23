using System;
namespace MotelHubApi;

public class BaseAreaModel
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double? Longtitude { get; set; }
    public double? Latitude { get; set; }
    public int HostId { get; set; }

    public BaseUserModel? Host { get; set; }
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseRoomModel> Rooms { get; set; } = new HashSet<BaseRoomModel>();
}

