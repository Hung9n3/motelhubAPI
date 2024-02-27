using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

[Authorize(Policy = "IsUser")]
public class RatingAndReviewController : ApiControllerBase
{
    public RatingAndReviewController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await base._mediator.Send(new GetRatingAndReviewByIdQuery(id));
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRatingAndReviewCommand command)
    {
        var userId = base.GetUserId();
        if(userId != command.UserId)
        {
            return Unauthorized();
        }
        await base._mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRatingAndReviewCommand command)
    {
        var userId = base.GetUserId();
        if (userId != command.UserId)
        {
            return Unauthorized();
        }
        command.UserId = userId;
        await base._mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteRatingAndReviewCommand command)
    {
        var userId = base.GetUserId();
        if (userId != command.UserId)
        {
            return Unauthorized();
        }
        await base._mediator.Send(command);
        return Ok();
    }
}

