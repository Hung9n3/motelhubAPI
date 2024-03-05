using System;
namespace MotelHubApi;

public class BaseRoomModel : BaseEntityModel
{
    public decimal Price { get; set; }
    public string? Name { get; set; }
    public double Acreage { get; set; }
    public int? OwnerId { get; set; }
    public int? AreaId { get; set; }
    public double Rating { get; set; }
}

