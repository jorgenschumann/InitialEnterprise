using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations
{
    public class UserNavigationMenuGroupTypeConfiguration : IEntityTypeConfiguration<UserNavigationMenuGroup>
    {
        public void Configure(EntityTypeBuilder<UserNavigationMenuGroup> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.UserNavigationId);
            builder.Property(o => o.DisplayName);
            builder.HasKey(o => o.Id);         
        }
    }
}