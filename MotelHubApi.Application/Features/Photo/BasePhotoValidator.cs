using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BasePhotoValidator<TCommand> : AbstractValidator<TCommand> where TCommand : BasePhotoModel
{
    public BasePhotoValidator()
    {
        RuleFor(cmd => cmd).Must(x => !string.IsNullOrWhiteSpace(x.Url) || (x.Data is not null && x.Data != Array.Empty<byte>())).WithMessage($"Data and Url are both empty");
        RuleFor(cmd => cmd).Must(x => x.UserId != 0 || x.RoomId != 0 || x.AreaId != 0 || x.MeterReadingId != 0 || x.ContractId != 0).WithMessage($"At least a foreign key have to be set");
    }
}
