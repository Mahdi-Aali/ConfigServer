using Autofac;
using Autofac.Extensions.DependencyInjection;
using ConfigServer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConfigServer.API.Configurations;

public static class ApiApplicationBootstrapperExtenssions
{
    public static IServiceCollection LoadServices(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies, CancellationToken cancellationToken = default)
    {
        AddEndpointApiExplorer(services);
        AddSwaggerGen(services);
        AddControllers(services);
        AddDbContext(services, configuration);
        AddMediatR(services, assemblies);
        AddAutoMapper(services, assemblies);
        AddHostedServices(services);
        return services;
    }

    public static WebApplicationBuilder LoadContainers(this WebApplicationBuilder builder, Assembly[] assemblies)
    {
        builder.Host
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(cfg =>
            {
                cfg.RegisterAssemblyModules(assemblies);
            });
        return builder;
    }

    public static WebApplication AddConfigures(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseSwaggerUI();
        app.UseSwagger();
        app.UseRouting();
        app.MapControllers();
        app.MapGet("/", async (HttpContext context) => await context.Response.WriteAsync("Config server"));
        return app;
    }


    private static IServiceCollection AddEndpointApiExplorer(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        return services;
    }
    private static IServiceCollection AddSwaggerGen(IServiceCollection services)
    {
        services.AddSwaggerGen();
        return services;
    }
    private static IServiceCollection AddControllers(IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
    private static IServiceCollection AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"), ssopt =>
            {
                ssopt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);

                ssopt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null);
            });
        });

        return services;
    }
    private static IServiceCollection AddMediatR(IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(assemblies);
        });
        return services;
    }

    private static IServiceCollection AddAutoMapper(IServiceCollection services, Assembly[] assemblies)
    {
        services.AddAutoMapper(assemblies);
        return services;
    }

    private static IServiceCollection AddHostedServices(IServiceCollection services)
    {
        services.AddHostedService<Worker>();
        return services;
    }
}
