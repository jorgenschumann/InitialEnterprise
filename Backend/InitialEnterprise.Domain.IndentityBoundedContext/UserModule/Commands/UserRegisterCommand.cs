using InitialEnterprise.Infrastructure.DDD.Command;
using System;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands
{
    public class UserRegisterCommand : DomainCommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}