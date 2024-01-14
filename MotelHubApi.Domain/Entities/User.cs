using Microsoft.AspNetCore.Identity;

namespace MotelHubApi;

public class User : IdentityUser<int>
{
    public int? OwningRoom { get; set; }
    public Room? Room { get; set; }
}