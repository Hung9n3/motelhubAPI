using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

public class UserController : ApiControllerBase<User, IUserLogic>
{
    public UserController(IUserLogic logic) : base(logic)
    {
    }
}

