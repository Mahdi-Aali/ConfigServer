using ConfigServer.Domain.SeedWorker;

namespace ConfigServer.Domain.AggregateModels.ApplicationAggregate;

public interface IApplicationRepository : IRepository<Application>
{
    public Task<bool> AddAsync(Application application, CancellationToken cancellationToken = default);
    public Task<bool> IsApplicationNameExist(string name, CancellationToken cancellationToken = default);
}