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
        var hostId = User.Claims.First(c => c.Type == "UserId").Value;
        if(hostId == null || hostId == string.Empty)
        {
            return Unauthorized();
        }
        command.HostId = int.Parse(hostId);
        var result = await base._mediator.Send(command);
        return Ok(result);
    }
}

