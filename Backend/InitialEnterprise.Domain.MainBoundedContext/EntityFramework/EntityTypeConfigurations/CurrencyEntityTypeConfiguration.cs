using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public  class CurrencyEntityTypeConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id);
            builder.Property(o => o.Name);
            builder.Property(o => o.IsoCode);
            builder.Property(o => o.Rate);
            //builder.Ignore(b => b.DomainEvents);
        }
    }
}
