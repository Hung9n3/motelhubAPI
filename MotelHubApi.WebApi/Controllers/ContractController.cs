using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class ContractController : ApiControllerBase
{
    public ContractController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await base._mediator.Send(new GetContractByIdQuery { Id = id});
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContractCommand command)
    {
        var result = await base._mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContractCommand command)
    {
        await base._mediator.Send(command);
        return Ok();
    }
}
