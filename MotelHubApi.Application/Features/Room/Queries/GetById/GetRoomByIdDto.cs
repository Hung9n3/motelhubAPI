using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetRoomByIdDto : BaseRoomModel
{
    public BaseAreaModel? Area { get; set; }
    public BaseUserModel? Owner { get; set; }
    public ICollection<BaseUserModel> Members { get; set; } = new HashSet<BaseUserModel>();
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseMeterReadingModel> MeterReadings { get; set; } = new HashSet<BaseMeterReadingModel>();
    public ICollection<BaseContractModel> Contracts { get; set; } = new HashSet<BaseContractModel>();
}
