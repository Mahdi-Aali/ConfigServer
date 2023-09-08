using ConfigServer.Domain.SeedWorker;

namespace ConfigServer.Domain.CommonExceptions;

public class PublishingEventsException : ExceptionBase
{
    public PublishingEventsException(string description) : base(description)
    {
        
    }
}
