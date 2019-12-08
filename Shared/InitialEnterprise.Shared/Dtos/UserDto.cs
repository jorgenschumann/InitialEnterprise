using System;
using System.Collections.Generic;

namespace InitialEnterprise.Shared.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumberConfirmed { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Image { get; set; } 

        public IEnumerable<ApplicationUserClaimDto> Claims { get; set; }
    }

    public class ApplicationUserClaimDto
    {
        public virtual int Id { get; set; }

        public virtual string ClaimType { get; set; }

        public virtual string ClaimValue { get; set; }
    }

}