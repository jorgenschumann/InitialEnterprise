using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {            
            builder.Property(o => o.Id);
            builder.Property(o => o.Name);
         
            builder.HasKey(o => o.Id);
            builder.Ignore(o => o.UserId);
            builder.Ignore(b => b.Events);
        }
    }
}