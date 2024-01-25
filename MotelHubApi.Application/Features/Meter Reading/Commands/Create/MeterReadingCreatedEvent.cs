using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class MeterReadingCreatedEvent : BaseEvent
{
    public MeterReading MeterReading;
    public MeterReadingCreatedEvent(MeterReading meterReading)
    {
        this.MeterReading = meterReading;
    }
}
