using ConfigServer.Domain.AggregateModels.ApplicationAggregate.Events;
using LoggerService;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ConfigServer.Application.EventHandlers.ApplicationEventHandlers;

public class ApplicationCreatedEventHandler : INotificationHandler<ApplicationCreatedEvent>
{
    private ILoggerManager _loggerManager;

    public ApplicationCreatedEventHandler(ILoggerManager loggerManager) => _loggerManager = loggerManager;


    public async Task Handle(ApplicationCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            _loggerManager.LogInfo($"a new application created successfully! {JsonSerializer.Serialize(notification)}");
        });
    }
}
