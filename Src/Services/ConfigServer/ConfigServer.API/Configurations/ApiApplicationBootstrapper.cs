using ConfigServer.Application.Command;
using NLog;
using System.Reflection;

namespace ConfigServer.API.Configurations;

public abstract class ApiApplicationBootstrapper : ApplicationBootstrapper
{
    private readonly Assembly[] _assemblies;

    public ApiApplicationBootstrapper() => _assemblies = GetAllAssemblies();

    public virtual Assembly[] GetAllAssemblies() =>
        Assembly.GetEntryAssembly()!
        .GetReferencedAssemblies()
        .Select(asm => Assembly.Load(asm))
        .Where(asm => asm.GetName().Name!.ToLower().Contains("configserver"))
        .Concat(new Assembly[2] { Assembly.GetExecutingAssembly(), typeof(CommandResult).Assembly })
        .Distinct()
        .ToArray();

    public override async Task ConfigureService(WebApplicationBuilder builder)
    {
        await base.ConfigureService(builder);
        builder.Services.LoadServices(Configuration, _assemblies);
        builder.LoadContainers(_assemblies);
        LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
    }

    public override async Task Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.AddConfigures();
        await base.Configure(app, env);
    }
}
