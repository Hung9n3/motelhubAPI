using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class BillController : ApiControllerBase
{
    public BillController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await base._mediator.Send(new GetBillByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBillCommand command)
    {
        var result = await base._mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBillCommand command)
    {
        await base._mediator.Send(command);
        return Ok();
    }
}
