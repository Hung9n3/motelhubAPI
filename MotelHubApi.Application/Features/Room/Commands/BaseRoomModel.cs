using System;
namespace MotelHubApi;

public class BaseRoomModel : BaseEntityModel
{
    public string? Name { get; set; }
    public double Acreage { get; set; }
    public int? OwnerId { get; set; }
    public int? AreaId { get; set; }
}

