using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotelHubApi.Shared;

namespace MotelHubApi.WebApi;

public class NotificationController : ApiControllerBase<Notification, INotificationLogic>
{
    public NotificationController(INotificationLogic logic) : base(logic)
    {
    }
}

