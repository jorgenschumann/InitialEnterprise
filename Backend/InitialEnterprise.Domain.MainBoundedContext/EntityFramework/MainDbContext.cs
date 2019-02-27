using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Aggregate;
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

        public DbSet<CurrencyRate> CurrencyRate { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<EmailAddress> EmailAddress { get; set; }

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

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmailAddress>()
               .HasOne(p => p.Person)
               .WithMany(e => e.EmailAddresses)
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
    }
}