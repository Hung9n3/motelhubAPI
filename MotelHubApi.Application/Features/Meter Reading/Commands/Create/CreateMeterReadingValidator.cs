using System;
using FluentValidation;
namespace MotelHubApi;

public class CreateMeterReadingValidator : BaseMeterReadingValidator<CreateMeterReadingCommand>
{
    public CreateMeterReadingValidator() : base()
    {
    }
}

