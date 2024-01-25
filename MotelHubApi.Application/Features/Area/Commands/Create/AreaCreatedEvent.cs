using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class AreaCreatedEvent : BaseEvent
{
    public Area Area;
    public AreaCreatedEvent(Area area)
    {
        this.Area = area;
    }
}
