using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.UserId);
            builder.Property(o => o.FirstName);
            builder.Property(o => o.MiddleName);
            builder.Property(o => o.LastName);          
            builder.Property(o => o.NameStyle);
            builder.Property(o => o.PersonType);
            builder.Property(o => o.Suffix);
            builder.Property(o => o.Title);       

            builder.HasKey(o => o.Id);
            builder.Ignore(o => o.UserId);
            builder.Ignore(b => b.Events);
        }
    }
}