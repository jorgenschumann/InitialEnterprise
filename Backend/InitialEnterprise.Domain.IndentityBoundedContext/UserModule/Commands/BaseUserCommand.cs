using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands
{
    public abstract class BaseUserCommand: DomainCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}