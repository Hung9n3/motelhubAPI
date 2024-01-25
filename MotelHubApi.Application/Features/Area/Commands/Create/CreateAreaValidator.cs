using System;
using FluentValidation;
namespace MotelHubApi;

public class CreateAreaValidator : BaseAreaValidator<CreateAreaCommand>
{
    public CreateAreaValidator() : base()
    {
    }
}

