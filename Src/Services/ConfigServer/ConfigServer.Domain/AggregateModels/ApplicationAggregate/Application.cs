using ConfigServer.Domain.AggregateModels.ApplicationAggregate.Events;
using ConfigServer.Domain.SeedWorker;

namespace ConfigServer.Domain.AggregateModels.ApplicationAggregate;

public class Application : Entity, IAggregateRoot
{
    public string ApplicationName { get; set; } = string.Empty;
    public Guid ApplicationSecret { get; set; }
    public string Configuration { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }


    protected Application()
    {
        
    }

    public Application(Guid id, string applicationName, Guid applicationSecret, string configuration, DateTime createDate, DateTime? updateDate)
    {
        Id = id;
        ApplicationName = applicationName;
        ApplicationSecret = applicationSecret;
        Configuration = configuration;
        CreateDate = createDate;
        UpdateDate = updateDate;
    }

    protected Application(string name, string configuration) : this(Guid.NewGuid(), name, Guid.NewGuid(), configuration, DateTime.Now, null)
    {
        AddDomainEvent(new ApplicationCreatedEvent(name, this.Id));
    }



    public class ApplicationFactory
    {
        public Application CreateNew(string name, string configuration) =>
            new(name, configuration);
    }

    public static ApplicationFactory Factory => new();
}