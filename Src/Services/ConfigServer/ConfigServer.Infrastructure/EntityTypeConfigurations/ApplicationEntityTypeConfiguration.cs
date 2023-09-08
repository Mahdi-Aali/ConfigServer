using ConfigServer.Domain.AggregateModels.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigServer.Infrastructure.EntityTypeConfigurations;

public class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications", ApplicationDbContext.DEFAULT_SCHIMA);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ApplicationName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.ApplicationSecret).IsRequired();
        builder.Property(x => x.Configuration).IsRequired();
        builder.Property(x => x.CreateDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);

        builder.Ignore(x => x.DomainEvents);

        builder.HasIndex(x => x.ApplicationName);
        builder.HasIndex(x => x.ApplicationSecret);
    }
}
