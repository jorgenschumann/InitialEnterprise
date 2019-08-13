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
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
               // Each User can have many UserClaims
               b.HasMany(e => e.Claims)
                  .WithOne(e => e.User)
                  .HasForeignKey(uc => uc.UserId)
                  .IsRequired();

               // Each User can have many UserLogins
               b.HasMany(e => e.Logins)
                  .WithOne(e => e.User)
                  .HasForeignKey(ul => ul.UserId)
                  .IsRequired();

               // Each User can have many UserTokens
               b.HasMany(e => e.Tokens)
                  .WithOne(e => e.User)
                  .HasForeignKey(ut => ut.UserId)
                  .IsRequired();

               // Each User can have many entries in the UserRole join table
               b.HasMany(e => e.UserRoles)
                  .WithOne(e => e.User)
                  .HasForeignKey(ur => ur.UserId)
                  .IsRequired();
           });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                   .WithOne(e => e.Role)
                   .HasForeignKey(ur => ur.RoleId)
                   .IsRequired();

                // Each Role can have many associated RoleClaims
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