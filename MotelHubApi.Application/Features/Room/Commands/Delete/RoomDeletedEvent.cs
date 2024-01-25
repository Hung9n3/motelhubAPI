using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class RoomDeletedEvent : BaseEvent
{
    public Room Room { get; set; }
    public RoomDeletedEvent(Room room)
    {
        this.Room = room;
    }
}
