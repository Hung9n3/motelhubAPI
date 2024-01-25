using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateMeterReadingValidator : BaseMeterReadingValidator<UpdateMeterReadingCommand>
{
    public UpdateMeterReadingValidator() : base()
    {
    }
}

