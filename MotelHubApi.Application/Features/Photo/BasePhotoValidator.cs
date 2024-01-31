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
        RuleFor(cmd => cmd).Must(x => x.UserId.IsPositive() || x.RoomId.IsPositive() || x.AreaId.IsPositive() || x.MeterReadingId.IsPositive() || x.ContractId.IsPositive()).WithMessage($"At least a foreign key have to be set");
    }
}
