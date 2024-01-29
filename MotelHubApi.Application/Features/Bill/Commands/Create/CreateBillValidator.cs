using System;
using FluentValidation;
namespace MotelHubApi;

public class CreateBillValidator : BaseBillValidator<CreateBillCommand>
{
    public CreateBillValidator() : base()
    {
    }
}

