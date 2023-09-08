namespace ConfigServer.Domain.SeedWorker;

public interface IUnitOfWork
{
    public Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}