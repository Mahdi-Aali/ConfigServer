using ConfigServer.Domain.SeedWorker;

namespace ConfigServer.Domain.CommonExceptions;

public class ItemAlreadyExistException : ExceptionBase
{
    public ItemAlreadyExistException(string description) : base(description)
    {

    }
}