using ConfigServer.Domain.SeedWorker;
using MediatR;

namespace ConfigServer.Infrastructure;

public static class MediatorApplicationContextExtenssions
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, ApplicationDbContext context)
    {

        var domainEntities = context.ChangeTracker
        .Entries<Entity>()
        .Where(e => e.Entity.DomainEvents.Any())
        .ToList();

        var domainEvents = domainEntities.SelectMany(s => s.Entity.DomainEvents).ToList();

        domainEntities.ForEach(de => de.Entity.ClearDomainEvents());

        foreach (var item in domainEvents)
        {
            await mediator.Publish(item);
        }
    }
}
