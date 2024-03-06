using System;
using Nest;
namespace MotelHubApi;

public interface IEntity
{
    [PropertyName(nameof(Id))]
    public int Id { get; set; }

    [PropertyName(nameof(CreatedAt))]
    public DateTime CreatedAt { get; set; }

    [PropertyName(nameof(ModifiedAt))]
    public DateTime ModifiedAt { get; set; }

    [PropertyName(nameof(IsActive))]
    public bool IsActive { get; set; }
}

