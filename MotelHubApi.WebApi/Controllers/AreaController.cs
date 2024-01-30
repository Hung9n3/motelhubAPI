using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

[Authorize(Policy = "IsUser")]
public class AreaController : ApiControllerBase
{
    public AreaController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
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

    [HttpGet("{areaId}")]
    public async Task<IActionResult> GetById(int areaId)
    {
        var result = await base._mediator.Send(new GetAreaByIdQuery(areaId));
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAreaCommand command)
    {
        await base._mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteAreaCommand command)
    {
        await base._mediator.Send(command);
        return Ok();
    }
}

