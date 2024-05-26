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
}

