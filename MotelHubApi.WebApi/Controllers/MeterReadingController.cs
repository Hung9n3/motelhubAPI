using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class MeterReadingController : ApiControllerBase
{
    public MeterReadingController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMeterReadingCommand command)
    {
        var result = await base._mediator.Send(command);
        return Ok(result);
    }
}
