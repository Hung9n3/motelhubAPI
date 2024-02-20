using MediatR;

namespace MotelHubApi.WebApi;

public class BillController : ApiControllerBase
{
    public BillController(IMediator mediator) : base(mediator)
    {
    }
}
