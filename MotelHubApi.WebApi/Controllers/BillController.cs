using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotelHubApi.Infrastructure;

namespace MotelHubApi.WebApi;

public class BillController : ApiControllerBase<Bill, IBillLogic>
{
    public BillController(BillLogic logic) : base(logic)
    {
    }
}
