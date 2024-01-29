using System;
using FluentValidation;
namespace MotelHubApi;

public class CreateContractValidator : BaseContractValidator<CreateContractCommand>
{
    public CreateContractValidator() : base()
    {
    }
}

