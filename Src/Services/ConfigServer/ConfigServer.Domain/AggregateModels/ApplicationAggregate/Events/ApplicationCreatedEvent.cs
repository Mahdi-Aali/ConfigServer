using MediatR;

namespace ConfigServer.Domain.AggregateModels.ApplicationAggregate.Events;

public class ApplicationCreatedEvent : INotification
{
    public string ApplicationName { get; set; } = string.Empty;
    public Guid ApplicationId { get; set; }

    public ApplicationCreatedEvent()
    {
    }

    public ApplicationCreatedEvent(string applicationName, Guid applicationId) =>
        (ApplicationName, ApplicationId) = (applicationName, applicationId);
}
