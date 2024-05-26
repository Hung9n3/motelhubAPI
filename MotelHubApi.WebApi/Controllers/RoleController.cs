using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class RoleController : ApiControllerBase<Role, IRoleLogic>
{
    public RoleController(IRoleLogic logic) : base(logic)
    {
    }
}

