using ConfigServer.Domain.AggregateModels.ApplicationAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ConfigServer.Application.EventHandlers.ApplicationEventHandlers;

public class ApplicationCreatedEventHandler : INotificationHandler<ApplicationCreatedEvent>
{
    private ILogger<ApplicationCreatedEventHandler> _logger;

    public ApplicationCreatedEventHandler(ILogger<ApplicationCreatedEventHandler> logger) => _logger = logger;


    public async Task Handle(ApplicationCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            _logger.LogInformation($"a new application created successfully! {JsonSerializer.Serialize(notification)}");
        });
    }
}
