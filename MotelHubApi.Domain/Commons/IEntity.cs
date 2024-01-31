using System;
namespace MotelHubApi;

public interface IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }
}

