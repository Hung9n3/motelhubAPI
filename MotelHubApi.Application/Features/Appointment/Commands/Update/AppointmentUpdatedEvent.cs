using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class AppointmentUpdatedEvent : BaseEvent
{
    public Appointment Appointment { get; set; }
    public AppointmentUpdatedEvent(Appointment appointment)
    {
        this.Appointment = appointment;
    }
}
