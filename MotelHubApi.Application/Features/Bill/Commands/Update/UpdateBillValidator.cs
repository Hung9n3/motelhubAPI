using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateBillValidator : BaseBillValidator<UpdateBillCommand>
{
    public UpdateBillValidator() : base()
    {
        RuleFor(command => command)
            .Must(x => x.ElectricLastMonth.IsPositive() && x.ElectricThisMonth.IsPositive() && x.WaterLastMonth.IsPositive() && x.WaterLastMonth.IsPositive());
    }
}

