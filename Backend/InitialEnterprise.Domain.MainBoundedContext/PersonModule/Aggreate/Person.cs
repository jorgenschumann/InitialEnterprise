using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.DDD.Event;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PersonUpdated : DomainEvent
    {
        public string CommandJson { get; set; }
    }

    public class PersonCreated : DomainEvent
    {
        public string CommandJson { get; set; }
    }

    public class Person : AggregateRoot
    {
        private Person()
        {
            EmailAddress = new HashSet<EmailAddress>();
            PersonCreditCard = new HashSet<PersonCreditCard>();
            PersonPhone = new HashSet<PersonPhone>();
        }

        public Person(CreatePersonCommand command)
        {
            if (command.IsValid)
            {
                this.CopyPropertiesFrom(command);

                AddEvent(new PersonCreated
                {
                    AggregateRootId = Id,
                    CommandJson = JsonConvert.SerializeObject(command),
                    UserId = command.UserId
                });
            }
        }

        public Person Update(UpdatePersonCommand command)
        {
            if (command.IsValid)
            {
                this.CopyPropertiesFrom(command);

                AddEvent(new PersonUpdated
                {
                    AggregateRootId = Id,
                    CommandJson = JsonConvert.SerializeObject(command),
                    UserId = command.UserId
                });
            }

            return this;
        }

        public string PersonType { get; }

        public bool NameStyle { get; }

        public string Title { get; }

        public string FirstName { get; }

        public string MiddleName { get; }

        public string LastName { get; }

        public string Suffix { get; }

        public int EmailPromotion { get; }

        public virtual ICollection<EmailAddress> EmailAddress { get; private set; }

        public virtual ICollection<PersonCreditCard> PersonCreditCard { get; private set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; private set; }
    }
}