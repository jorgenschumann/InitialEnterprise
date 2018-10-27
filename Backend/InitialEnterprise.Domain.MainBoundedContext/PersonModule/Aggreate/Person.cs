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
        [JsonConstructor]
        private Person()
        {
            EmailAddresses = new HashSet<EmailAddress>();
            //PersonCreditCard = new HashSet<PersonCreditCard>();
            //PersonPhone = new HashSet<PersonPhone>();
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

        [JsonProperty]
        public string PersonType { get; private set; }

        [JsonProperty]
        public bool NameStyle { get; private set; }

        [JsonProperty]
        public string Title { get; private set; }

        [JsonProperty]
        public string FirstName { get; private set; }

        [JsonProperty]
        public string MiddleName { get; private set; }

        [JsonProperty]
        public string LastName { get; private set; }

        [JsonProperty]
        public string Suffix { get; private set; }

        [JsonProperty]
        public int EmailPromotion { get; private set; }

        [JsonProperty]
        public ICollection<EmailAddress> EmailAddresses { get; private set; }

        //public virtual ICollection<PersonCreditCard> PersonCreditCard { get; private set; }

        //public virtual ICollection<PersonPhone> PersonPhone { get; private set; }
    }
}