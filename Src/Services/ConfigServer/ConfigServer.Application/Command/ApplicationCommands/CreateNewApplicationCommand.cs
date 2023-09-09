using ConfigServer.Domain.AggregateModels.ApplicationAggregate;
using ConfigServer.Domain.CommonExceptions;
using LoggerService;
using MediatR;

namespace ConfigServer.Application.Command.ApplicationCommands;

public class CreateNewApplicationCommandResult : CommandResult
{
    public bool Result { get; set; }
}


public class CreateNewApplicationCommand : IRequest<CreateNewApplicationCommandResult>
{
    public string ApplicationName { get; set; } = string.Empty;
    public string Configuration { get; set; } = string.Empty;

    public CreateNewApplicationCommand()
    {
        
    }

    public CreateNewApplicationCommand(string applicationName, string configuration)
    {
        ApplicationName = applicationName;
        Configuration = configuration;
    }
}


public class CreateNewApplicationCommandHandler : IRequestHandler<CreateNewApplicationCommand, CreateNewApplicationCommandResult>
{
    private readonly IApplicationRepository _repository;
    private readonly ILoggerManager _loggerManager;

    public CreateNewApplicationCommandHandler(IApplicationRepository repository, ILoggerManager loggerManager) 
        => (_repository, _loggerManager) = (repository, loggerManager);

    public async Task<CreateNewApplicationCommandResult> Handle(CreateNewApplicationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddAsync(app.Application.Factory.CreateNew(request.ApplicationName, request.Configuration), cancellationToken);
            bool result = (await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken)) > 0;
            return new()
            {
                Result = result,
                ErrorMessage = result ? null : "Some thing went wrong. please try again later and call support team."
            };
        }
        catch (ItemAlreadyExistException ex)
        {
            return new()
            {
                Result = false,
                ErrorMessage = ex.Message
            };
        }
        catch (Exception ex)
        {
            _loggerManager.LogError(ex);
            return new()
            {
                Result = false,
                ErrorMessage = "Something went wrong please try again or call supprt."
            };
        }
    }
}