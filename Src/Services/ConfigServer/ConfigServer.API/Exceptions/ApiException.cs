namespace ConfigServer.API.Exceptions;

public class ApiExceptions
{
    private List<string> _errors;

    public ApiExceptions()
    {
        _errors = new();
    }

    public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();

    public void AddErrorMessage(string msg) => _errors.Add(msg);
}
