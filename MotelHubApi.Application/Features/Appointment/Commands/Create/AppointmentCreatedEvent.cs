using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class AppointmentCreatedEvent : BaseEvent
{
    public Appointment Appointment { get; set; }
    public AppointmentCreatedEvent(Appointment appointment)
    {
        this.Appointment = appointment;
    }
}
