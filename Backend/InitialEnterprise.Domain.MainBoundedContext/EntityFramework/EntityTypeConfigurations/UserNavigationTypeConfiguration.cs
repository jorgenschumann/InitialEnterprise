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

    public class UserNavigationMenuGroupItemTypeConfiguration : IEntityTypeConfiguration<UserNavigationMenuGroupItem>
    {
        public void Configure(EntityTypeBuilder<UserNavigationMenuGroupItem> builder)
        {
            builder.Property(o => o.Id);
            builder.Property(o => o.GroupId);
            builder.Property(o => o.DisplayName);
            builder.Property(o => o.Href);
            builder.Property(o => o.Icon); 

            builder.HasKey(o => o.Id);           
        }
    }  
}