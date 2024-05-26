using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class AreaController : ApiControllerBase<Area, IAreaLogic>
{
    public AreaController(IAreaLogic logic) : base(logic)
    {
    }
}

