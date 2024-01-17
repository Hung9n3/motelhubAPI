using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class RoleController : ApiControllerBase
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand command)
    {
        var result = await base._mediator.Send(command);
        return Ok(result);
    }
}

