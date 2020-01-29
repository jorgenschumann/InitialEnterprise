using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.IndentityBoundedContext.UserModule.Commands
{
    public class SignOutCommand : DomainCommand
    {
        public string Email { get; set; }      
    }
}