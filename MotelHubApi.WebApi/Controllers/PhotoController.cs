using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class PhotoController : ApiControllerBase
{
    public PhotoController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var result = await base._mediator.Send(new GetPhotoByUserQuery(userId));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMeterReadingCommand command)
    {
        var result = await base._mediator.Send(command);
        return Ok(result);
    }
}
