using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands
{
    public abstract class BaseMailAddressCommand : DomainCommand
    {
        public string MailAddress { get; set; }

        public virtual Person Person { get; set; }

        public bool IsValid => true;
    }
}