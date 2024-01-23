using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseUserModel
{
    public string Fullname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public BaseRoleModel? Role { get; set; }

    public ICollection<BaseRoomModel> OwnRooms { get; set; } = new HashSet<BaseRoomModel>();
    public ICollection<BaseRoomModel> LivingRooms { get; set; } = new HashSet<BaseRoomModel>();
    public ICollection<UserRoom> UserRooms { get; set; } = new HashSet<UserRoom>();
    public ICollection<BaseContractModel> HostContracts { get; set; } = new HashSet<BaseContractModel>();
    public ICollection<BaseContractModel> CustomerContracts { get; set; } = new HashSet<BaseContractModel>();
    public ICollection<BasePhotoModel> Photos { get; set; } = new HashSet<BasePhotoModel>();
    public ICollection<BaseAreaModel> Areas { get; set; } = new HashSet<BaseAreaModel>();
}
