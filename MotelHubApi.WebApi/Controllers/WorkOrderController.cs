using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class WorkOrderController : ApiControllerBase<WorkOrder, IWorkOrderLogic>
{
    public WorkOrderController(IWorkOrderLogic logic) : base(logic)
    {
    }
}

