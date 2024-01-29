using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class MeterReadingDeletedEvent : BaseEvent
{
    public MeterReading MeterReading { get; set; }
    public MeterReadingDeletedEvent(MeterReading meterReading)
    {
        this.MeterReading = meterReading;
    }
}
