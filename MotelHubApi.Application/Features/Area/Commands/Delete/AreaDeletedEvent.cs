using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class AreaDeletedEvent : BaseEvent
{
    public Area Area { get; set; }
    public AreaDeletedEvent(Area area)
    {
        Area = area;
    }
}
