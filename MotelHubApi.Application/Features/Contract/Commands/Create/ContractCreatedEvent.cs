using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class ContractCreatedEvent : BaseEvent
{
    public Contract Contract;
    public ContractCreatedEvent(Contract contract)
    {
        this.Contract = contract;
    }
}
