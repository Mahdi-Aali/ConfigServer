using ConfigServer.Domain.AggregateModels.ApplicationAggregate;
using ConfigServer.Domain.SeedWorker;
using ConfigServer.Infrastructure.EntityTypeConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConfigServer.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHIMA = "application";
    private readonly IMediator _mediator;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Application> Applications => Set<Application>();

    public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationEntityTypeConfiguration());
    }
}