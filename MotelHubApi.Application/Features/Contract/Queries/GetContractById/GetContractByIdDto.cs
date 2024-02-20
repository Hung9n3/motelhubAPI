using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetContractByIdDto : BaseContractModel
{
    public BaseUserModel? Customer { get; set; }
    public BaseUserModel? Host { get; set; }
    public BaseRoomModel? Room { get; set; }
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseBillModel> Bills { get; set; } = new List<BaseBillModel>();
}
