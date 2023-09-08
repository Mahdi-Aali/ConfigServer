using ConfigServer.Domain.SeedWorker;

namespace ConfigServer.Domain.CommonExceptions;

public class ItemNotFoundException : ExceptionBase
{
    public ItemNotFoundException(string description) : base(description)
    {
    }
}
