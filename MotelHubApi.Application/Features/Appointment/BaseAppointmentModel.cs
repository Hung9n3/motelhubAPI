using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;
public class BaseAppointmentModel : BaseEntityModel
{
    public string Title { get; set; } = string.Empty;
    public DateTime? DateTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public int? RoomId { get; set; }
    public int? HostId { get; set; }
    public int? CustomerId { get; set; }
}
