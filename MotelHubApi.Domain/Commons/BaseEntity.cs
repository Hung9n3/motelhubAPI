﻿using System.ComponentModel.DataAnnotations.Schema;
using Nest;

namespace MotelHubApi;

public class BaseEntity : IEntity
{
    private readonly List<BaseEvent> _domainEvents = new();

    public int Id { get; set; }

    [Ignore]
    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }

    public BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
        IsActive = true;
    }

    public void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void RemoveDomainEvent(BaseEvent domainEvent) => _domainEvents.Remove(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}

