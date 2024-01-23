using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseContractModel
{
    public string? Title { get; set; }
    public int? CustomerId { get; set; }
    public int? HostId { get; set; }
    public int? RoomId { get; set; }
    public string? RoomName { get; set; }
    public string? HostName { get; set; }
    public string? HostPhone { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? RoomAddress { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? CancelDate { get; set; }

    public BaseUserModel? Customer { get; set; }
    public BaseUserModel? Host { get; set; }
    public BaseRoomModel? Room { get; set; }
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseBillModel> Bills { get; set; } = new List<BaseBillModel>();
}
