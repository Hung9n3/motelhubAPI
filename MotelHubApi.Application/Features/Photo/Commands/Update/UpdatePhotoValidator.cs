using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdatePhotoValidator : BasePhotoValidator<UpdatePhotoCommand>
{
    public UpdatePhotoValidator() : base()
    {
    }
}

