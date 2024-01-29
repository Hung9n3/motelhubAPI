using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class PhotoUpdatedEvent : BaseEvent
{
    public Photo Photo { get; set; }
    public PhotoUpdatedEvent(Photo photo)
    {
        Photo = photo;
    }
}
