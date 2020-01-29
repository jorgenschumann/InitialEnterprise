using InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.SalesBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {            
            builder.Property(o => o.Id);
            builder.Property(o => o.PersonId);
            builder.Property(o => o.StoreId);
            builder.Property(o => o.TerritoryId);
            builder.Property(o => o.AccountNumber);

            builder.HasKey(o => o.Id);
            builder.Ignore(o => o.UserId);
            builder.Ignore(b => b.Events);
        }
    }
}