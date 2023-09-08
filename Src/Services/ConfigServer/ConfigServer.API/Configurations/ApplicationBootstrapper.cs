namespace ConfigServer.API.Configurations;

public abstract class ApplicationBootstrapper
{
    public IConfiguration Configuration { get; }

    public ApplicationBootstrapper() => Configuration = GetConfigurations();

    public virtual IConfiguration GetConfigurations() => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables()
            .Build();

    public virtual async Task ConfigureService(WebApplicationBuilder builder)
    {
        await Task.Run(() =>
        {
            builder.Configuration.AddConfiguration(Configuration);
        });
    }
    

    public virtual async Task Configure(WebApplication app, IWebHostEnvironment env)
    {
        await app.RunAsync();
    }
}
