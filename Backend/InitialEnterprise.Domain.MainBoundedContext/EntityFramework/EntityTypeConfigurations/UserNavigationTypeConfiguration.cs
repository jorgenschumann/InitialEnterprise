using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class UserNavigationTypeConfiguration : IEntityTypeConfiguration<UserNavigation>
    {
        public void Configure(EntityTypeBuilder<UserNavigation> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.UserId);
            builder.Property(o => o.DisplayName);            
            builder.HasKey(o => o.Id);                  
        }
    }
}