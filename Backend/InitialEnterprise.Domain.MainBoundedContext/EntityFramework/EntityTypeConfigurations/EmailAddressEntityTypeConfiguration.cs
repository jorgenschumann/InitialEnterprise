using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class EmailAddressEntityTypeConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.MailAddress);
            builder.HasKey(o => o.Id);          
        }
    }    
}