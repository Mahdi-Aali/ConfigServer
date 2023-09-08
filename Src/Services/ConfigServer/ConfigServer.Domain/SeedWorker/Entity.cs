using MediatR;

namespace ConfigServer.Domain.SeedWorker;

public abstract class Entity
{
    public virtual Guid Id { get; set; }

    public Entity() => (Id, _domainEvents) = (Guid.NewGuid(), new());

    private List<INotification> _domainEvents;

    public virtual IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public virtual void AddDomainEvent(INotification notification) => _domainEvents.Add(notification);
    public virtual void RemoveDomainEvent(INotification notification) => _domainEvents.Remove(notification);
    public virtual void ClearDomainEvents() => _domainEvents.Clear();
}