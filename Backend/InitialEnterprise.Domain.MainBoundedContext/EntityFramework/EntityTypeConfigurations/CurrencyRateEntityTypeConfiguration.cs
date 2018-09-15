using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class CurrencyRateEntityTypeConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.Property(o => o.Id);     
            builder.Property(o => o.FromCurrencyCode);
            builder.Property(o => o.ToCurrencyCode);
            builder.Property(o => o.AverageRate);
            builder.Property(o => o.CurrencyRateDate);
            builder.Property(o => o.EndOfDayRate);        

            builder.HasKey(o => o.Id);
            builder.Ignore(o => o.UserId);
            builder.Ignore(b => b.Events);
        }
    }
}