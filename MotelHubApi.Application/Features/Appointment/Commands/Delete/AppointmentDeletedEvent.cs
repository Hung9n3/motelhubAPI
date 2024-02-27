using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class AppointmentDeletedEvent : BaseEvent
{
    public Appointment Appointment { get; set; }
    public AppointmentDeletedEvent(Appointment appointment)
    {
        this.Appointment = appointment;
    }
}
