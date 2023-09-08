namespace ConfigServer.Application.Command;

public abstract class CommandResult
{
    public string? ErrorMessage { get; set; } = null!;
}
