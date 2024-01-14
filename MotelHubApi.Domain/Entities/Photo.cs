using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class Photo : BaseEntity
{
    public int UserId { get; set; }
    public int RoomId { get; set; }
    public int AreaId { get; set; }
    /// <summary>
    /// Child Item can be meter reading, contracts, and more in the future
    /// </summary>
    public int MeterReadingId { get; set; }
    public byte[]? Data { get; set; }
    public string? Url { get; set; }
    public User? User { get; set; }
    public Room? Room { get; set; }
    public Area? Area { get; set; }
    public MeterReading? MeterReading { get; set; }
}
