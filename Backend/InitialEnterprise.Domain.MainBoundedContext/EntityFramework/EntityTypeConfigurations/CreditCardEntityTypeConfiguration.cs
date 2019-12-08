using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class CreditCardEntityTypeConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.PersonId);
            builder.Property(o => o.CardNumber);
            builder.Property(o => o.CreditCardHolderName);
            builder.Property(o => o.CreditCardType);
            builder.Property(o => o.ExpireMonth);
            builder.Property(o => o.ExpireYear);
            builder.HasKey(o => o.Id);
        }
    }
}