using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotelHubApi.Infrastructure;

namespace MotelHubApi.WebApi;

public class AppointmentController : ApiControllerBase<Appointment, IAppointmentLogic>
{
    public AppointmentController(IAppointmentLogic logic) : base(logic)
    {
    }
}

