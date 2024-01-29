using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BillCreatedEvent : BaseEvent
{
    public Bill Bill;
    public BillCreatedEvent(Bill bill)
    {
        this.Bill = bill;
    }
}
