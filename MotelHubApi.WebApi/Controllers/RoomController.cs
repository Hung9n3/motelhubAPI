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

	[HttpGet("{roomId}")]
	public async Task<IActionResult> GetById(int roomId)
	{
		var result = await _mediator.Send(new GetRoomByIdQuery(roomId));
		if(result == null)
		{
			return NotFound();
		}
		return Ok(result);
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

	[HttpPut]
	public async Task<IActionResult> Update(UpdateRoomCommand command)
	{
		await _mediator.Send(command);
		return Ok();
	}
}

