using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class SignOutCommand : DomainCommand
    {
        public string Email { get; set; }      
    }
}