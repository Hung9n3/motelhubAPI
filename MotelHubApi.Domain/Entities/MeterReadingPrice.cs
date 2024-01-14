using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class MeterReadingPrice : BaseEntity
{
    public int Price { get; set; }
    public MeterReadingType Type { get; set; }
}
