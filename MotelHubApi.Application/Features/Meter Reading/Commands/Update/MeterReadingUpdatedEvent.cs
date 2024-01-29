using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class MeterReadingUpdatedEvent : BaseEvent
{
    public MeterReading MeterReading { get; set; }
    public MeterReadingUpdatedEvent(MeterReading meterReading)
    {
        this.MeterReading = meterReading;
    }
}
