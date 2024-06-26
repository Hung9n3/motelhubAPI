using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotelHubApi.Shared;

namespace MotelHubApi.WebApi;

public class RoomController : ApiControllerBase<Room, IRoomLogic>
{
    public RoomController(IRoomLogic logic) : base(logic)
    {
    }

    [HttpPost("search")]
    public async Task<IActionResult> Search([FromBody] SearchOptions options)
    {
        try
        {
            var result = await base._logic.Search(options);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

