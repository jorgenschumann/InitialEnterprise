using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
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
            builder.Property(o => o.PersonId);
            builder.Property(o => o.MailAddressType);
            builder.HasKey(o => o.Id);          
        }
    }
}