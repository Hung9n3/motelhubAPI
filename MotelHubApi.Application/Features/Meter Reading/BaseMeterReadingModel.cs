using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseMeterReadingModel 
{
    public string? Title { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public double? LastMonth { get; set; }
    public double? ThisMonth { get; set; }
    public double? Value { get; set; }
    public MeterReadingType Type { get; set; }
    public int? OwnerId { get; set; }
    public string? OwnerPhone { get; set; }
    public string? OwnerName { get; set; }
    public int RoomId { get; set; }
    public decimal? Price{ get; set; }

    public BaseUserModel? Owner { get; set; }
    public BaseRoomModel? Room { get; set; }
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
}
