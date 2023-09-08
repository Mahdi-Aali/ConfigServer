namespace ConfigServer.API.Configurations;

public abstract class ApiStartup<T> where T : ApplicationBootstrapper
{
    protected static async Task RunAsync()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        T startUp = (T)Activator.CreateInstance(typeof(T))!;
        await startUp.ConfigureService(builder);
        await startUp.Configure(builder.Build(), builder.Environment);
    }
}