using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class AreaUpdatedEvent : BaseEvent
{
    public Area Area { get; set; }
    public AreaUpdatedEvent(Area area)
    {
        Area = area;
    }
}
