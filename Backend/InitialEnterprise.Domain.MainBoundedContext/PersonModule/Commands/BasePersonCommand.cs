using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands
{
    public abstract class BasePersonCommand : DomainCommand
    {
        public bool IsValid => false;
            
        public string PersonType { get; set; }

        public bool NameStyle { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int EmailPromotion { get; set; }
    }
}