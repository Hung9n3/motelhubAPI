using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class RoomUpdatedEvent : BaseEvent
{
    public Room Room { get; set; }
    public RoomUpdatedEvent(Room room)
    {
        this.Room = room;
    }
}
