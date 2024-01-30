using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class GetAreaByIdDto : BaseAreaModel
{
    public BaseUserModel? Host { get; set; }
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseRoomModel> Rooms { get; set; } = new HashSet<BaseRoomModel>();
}
