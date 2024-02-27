using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseAppointmentValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BaseAppointmentModel
{
    public BaseAppointmentValidator()
    {
    }
}
