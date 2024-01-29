using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class PhotoDeletedEvent : BaseEvent
{
    public Photo Photo { get; set; }
    public PhotoDeletedEvent(Photo photo)
    {
        Photo = photo;
    }
}
