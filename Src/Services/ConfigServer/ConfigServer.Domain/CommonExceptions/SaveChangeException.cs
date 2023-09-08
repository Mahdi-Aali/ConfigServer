using ConfigServer.Domain.SeedWorker;

namespace ConfigServer.Domain.CommonExceptions;

public class SaveChangeException : ExceptionBase
{
    public SaveChangeException(string description) : base(description)
    {
        
    }
}
