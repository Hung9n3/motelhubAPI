using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

//[Authorize(Policy = "IsUser")]
public class AppointmentController : ApiControllerBase
{
    public AppointmentController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await base._mediator.Send(new GetAppointmentByIdQuery(id));
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
    {
        var userId = base.GetUserId();
        if(userId != command.HostId)
        {
            return Unauthorized();
        }
        await base._mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAppointmentCommand command)
    {
        var userId = base.GetUserId();
        if (userId != command.HostId)
        {
            return Unauthorized();
        }
        command.HostId = userId;
        await base._mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteAppointmentCommand command)
    {
        var userId = base.GetUserId();
        if (userId != command.HostId)
        {
            return Unauthorized();
        }
        await base._mediator.Send(command);
        return Ok();
    }
}

