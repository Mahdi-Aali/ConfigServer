using Autofac;
using ConfigServer.Domain.AggregateModels.ApplicationAggregate;
using ConfigServer.Infrastructure.Repositories;
using LoggerService;

namespace ConfigServer.API.Modules;

public class AutoFacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>().InstancePerLifetimeScope();
        builder.RegisterType<LoggerManager>().As<ILoggerManager>().SingleInstance();
    }
}
