namespace ConfigServer.Domain.SeedWorker;

public abstract class ExceptionBase : Exception
{
    public ExceptionBase()
    {
        
    }


    public ExceptionBase(string message) : base(message)
    {
        
    }
}
