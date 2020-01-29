using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CountryModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EntityFramework.EntityTypeConfigurations;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.EntityFramework
{
    public class MainDbContext : DbContext, IMainDbContext
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

        public virtual DbSet<Country> Country { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CurrencyRateEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new EmailAddressEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CreditCardEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PersonAddressEntityTypeConfiguration());
            
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
        }
    }
}