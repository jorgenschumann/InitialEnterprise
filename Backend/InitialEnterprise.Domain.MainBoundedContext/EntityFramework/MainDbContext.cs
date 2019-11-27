using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.DocumentModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext : IdentityDbContext<
         ApplicationUser, ApplicationRole, Guid,
         ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
         ApplicationRoleClaim, ApplicationUserToken>, IMainDbContext
    {
        public MainDbContext() : this(null)
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }

        public virtual DbSet<CurrencyRate> CurrencyRate { get; set; }

        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<EmailAddress> EmailAddress { get; set; }

        public virtual DbSet<CreditCard> CreditCard { get; set; }

        public virtual DbSet<PersonAddress> PersonAddress { get; set; }

        public virtual DbSet<Document> Document { get; set; }

        public virtual DbSet<Country> Country { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public virtual DbSet<UserNavigation> UserNavigation { get; set; }

        public virtual DbSet<UserNavigationMenuGroup> UserNavigationMenuGroup { get; set; }

        public virtual DbSet<UserNavigationMenuGroupItem> UserNavigationMenuGroupItem { get; set; }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureValueConverter(modelBuilder);

            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CurrencyRateEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EmailAddressEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CreditCardEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PersonAddressEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new DocumentEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ProvinceEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserNavigationTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserNavigationMenuGroupTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserNavigationMenuGroupItemTypeConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Province>()
              .HasOne(p => p.Country)
              .WithMany(e => e.Provinces)
              .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<PersonAddress>()
               .HasOne(p => p.Person)
               .WithMany(e => e.Addresses)
               .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<EmailAddress>()
               .HasOne(p => p.Person)
               .WithMany(e => e.EmailAddresses)
               .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<CreditCard>()
              .HasOne(p => p.Person)
              .WithMany(e => e.CreditCards)
              .HasForeignKey(e => e.PersonId);

           modelBuilder.Entity<ApplicationUser>(b =>
           {
                b.HasMany(e => e.Claims)
                  .WithOne(e => e.User)
                  .HasForeignKey(uc => uc.UserId)
                  .IsRequired();

               b.HasMany(e => e.Logins)
                  .WithOne(e => e.User)
                  .HasForeignKey(ul => ul.UserId)
                  .IsRequired();

                b.HasMany(e => e.Tokens)
                  .WithOne(e => e.User)
                  .HasForeignKey(ut => ut.UserId)
                  .IsRequired();

                b.HasMany(e => e.UserRoles)
                  .WithOne(e => e.User)
                  .HasForeignKey(ur => ur.UserId)
                  .IsRequired();
             
               b.HasOne(e => e.UserNavigation)
                  .WithOne(e => e.User)
                  .IsRequired();
           });

            modelBuilder.Entity<UserNavigation>(b => 
            {               
                b.HasMany(e => e.Groups)
                   .WithOne(e => e.UserNavigation)
                   .HasForeignKey(ur => ur.UserNavigationId)
                   .IsRequired();
            }); 

            modelBuilder.Entity<UserNavigationMenuGroup>(b =>
            {
                b.HasMany(e => e.Entries)
                   .WithOne(e => e.Group)
                   .HasForeignKey(ur => ur.GroupId)
                   .IsRequired();
            });

            modelBuilder.Entity<UserNavigationMenuGroupItem>(b =>
            {
                b.HasOne(e => e.Group)
                  .WithMany(e => e.Entries)
                   .HasForeignKey(ur => ur.GroupId)
                   .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                   .WithOne(e => e.Role)
                   .HasForeignKey(ur => ur.RoleId)
                   .IsRequired();

               b.HasMany(e => e.RoleClaims)
                   .WithOne(e => e.Role)
                   .HasForeignKey(rc => rc.RoleId)
                   .IsRequired();
            });
        }

        private void ConfigureValueConverter(ModelBuilder modelBuilder)
        {
            //var converter = new ValueConverter<CreditCardType, string>(
            //    v => v.ToString(),
            //    v => (CreditCardType)Enum.Parse(typeof(CreditCardType), v));

            //modelBuilder.Entity<CreditCard>().Property(
            //    e => e.CreditCardType).HasConversion(converter);
        }
    }
}