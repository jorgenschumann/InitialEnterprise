using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class PersonAddressEntityTypeConfiguration : IEntityTypeConfiguration<PersonAddress>
    {
        public void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.PersonId);
            builder.Property(o => o.Street);
            builder.Property(o => o.Number);          
            builder.Property(o => o.Province);
            builder.Property(o => o.Zip);
            builder.Property(o => o.Country);      
            
            builder.HasKey(o => o.Id);        
        }
    }
}
