using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MotelHubApi;

public class BaseRoleModel : IdentityRole<int>
{
    public ICollection<BaseUserModel> Users { get; set; } = new HashSet<BaseUserModel>();
}
