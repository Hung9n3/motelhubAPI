using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateAppointmentValidator : BaseAppointmentValidator<UpdateAppointmentCommand>
{
    public UpdateAppointmentValidator() : base()
    {
    }
}

