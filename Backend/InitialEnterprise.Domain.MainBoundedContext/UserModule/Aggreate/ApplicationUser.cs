using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [JsonIgnore]
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }

        [JsonIgnore]
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }

        [JsonIgnore]
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }

        [JsonIgnore]
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public string Token { get; set; }

        public ApplicationUser()
        {
        }

        public void Update(UserUpdateCommand command)
        {
            this.Email = command.Email;
            this.NormalizedEmail = this.Email.ToUpper();
            this.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(this, command.Password);
            //todo: set other values
        }

        public ApplicationUser(UserRegisterCommand command)
        {
            this.UserName = command.UserName;
            this.Email = command.Email;
            this.NormalizedEmail = this.Email.ToUpper();
            this.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(this, command.Password);
            //todo: set other values
        }

        private void SetCommandValues(BaseUserCommand command)
        {
            this.Email = command.Email;
            this.NormalizedEmail = this.Email.ToUpper();
            this.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(this, command.Password);
        }
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}