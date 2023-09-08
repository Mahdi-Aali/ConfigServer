namespace ConfigServer.Domain.SeedWorker;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }
}
