using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class AreaController : ApiControllerBase
{
    public AreaController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Authorize(Policy = "IsUser")]
    public async Task<IActionResult> Create([FromBody] CreateAreaCommand command)
    {
        var hostId = base.GetUserId();
        if(hostId <= 0)
        {
            return Unauthorized();
        }
        command.HostId = hostId;
        var result = await base._mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Policy = "IsUser")]
    public async Task<IActionResult> GetByOwner()
    {
        var hostId = base.GetUserId();
        if (hostId <= 0)
        {
            return Unauthorized();
        }

        var request = new GetAreaByOwnerQuery
        {
            HostId = hostId
        };

        var result = await this._mediator.Send(request);
        return Ok(result);
    }
}

