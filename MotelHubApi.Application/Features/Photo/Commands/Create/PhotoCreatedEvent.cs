using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class PhotoCreatedEvent : BaseEvent
{
    public Photo Photo { get; set; }
    public PhotoCreatedEvent(Photo photo)
    {
        Photo = photo;
    }
}
