using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class ContractUpdatedEvent : BaseEvent
{
    public Contract Contract { get; set; }
    public ContractUpdatedEvent(Contract contract)
    {
        this.Contract = contract;
    }
}
