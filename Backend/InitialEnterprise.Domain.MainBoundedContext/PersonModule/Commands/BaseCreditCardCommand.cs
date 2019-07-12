using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands
{
    public abstract class BaseCreditCardCommand : DomainCommand
    {
        public string PersonType { get; set; }
    }
}