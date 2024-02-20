using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BillUpdatedEvent : BaseEvent
{
    public Bill Bill { get; set; }
    public BillUpdatedEvent(Bill bill)
    {
        this.Bill = bill;
    }
}
