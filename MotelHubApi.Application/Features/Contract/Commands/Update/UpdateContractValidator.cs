using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateContractValidator : BaseContractValidator<UpdateContractCommand>
{
    public UpdateContractValidator() : base()
    {
    }
}

