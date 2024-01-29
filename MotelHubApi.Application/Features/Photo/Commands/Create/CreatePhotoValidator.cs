using System;
using FluentValidation;
namespace MotelHubApi;

public class CreatePhotoValidator : BasePhotoValidator<CreatePhotoCommand>
{
    public CreatePhotoValidator() : base()
    {
    }
}

