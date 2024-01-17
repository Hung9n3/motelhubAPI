using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotelHubApi.Shared;

namespace MotelHubApi.WebApi;

public class RoomController : ApiControllerBase
{
	public RoomController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet("area/{areaId}")]
	public async Task<IActionResult> GetByArea(int? areaId)
	{
		var result = await _mediator.Send(new GetRoomsByAreaQuery(areaId));
		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateRoomCommand command)
	{
		var result = await _mediator.Send(command);
		return CreatedAtAction(nameof(Create), new { id = result });
	}
}

