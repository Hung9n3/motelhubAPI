using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;
public class RoomIndex : BaseEntity
{
    public string Address { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public double? Acreage { get; set; }
    public string? ContactPhone { get; set; } = string.Empty;
}
