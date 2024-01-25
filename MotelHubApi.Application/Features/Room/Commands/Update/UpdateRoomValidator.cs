using System;
using FluentValidation;
namespace MotelHubApi;

public class UpdateRoomValidator : BaseRoomValidator<UpdateRoomCommand>
{
    public UpdateRoomValidator() : base()
    {
    }
}

