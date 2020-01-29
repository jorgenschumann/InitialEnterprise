using InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Aggreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.IndentityBoundedContext.EntityFramework
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

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                
   
            base.OnModelCreating(modelBuilder);
                        
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
        }    }
}