using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Events;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class Person : AggregateRoot
    {
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
        public virtual ICollection<EmailAddress> EmailAddresses { get; private set; }

        [JsonProperty]
        public virtual ICollection<PersonAddress> Addresses { get; private set; }

        [JsonProperty]
        public virtual ICollection<CreditCard> CreditCards { get; private set; }

        [JsonProperty]
        public virtual ICollection<PersonPhone> PersonPhones { get; private set; }

        [JsonConstructor]
        private Person()
        {
            EmailAddresses = new HashSet<EmailAddress>();
            CreditCards = new HashSet<CreditCard>();
            PersonPhones = new HashSet<PersonPhone>();
        }

        public Person(PersonCreateCommand command)
        {
            this.CopyPropertiesFrom(command);

            base.AddEvent(new PersonCreatedDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });
        }

        public Person Take(PersonUpdateCommand command)
        {
            this.CopyPropertiesFrom(command);

            base.AddEvent(new PersonUpdatedDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(EmailAddressDeleteCommand command)
        {
            var mail = EmailAddresses.First(e => e.Id == command.MailAddressId);

            this.EmailAddresses.Remove(mail);

            base.AddEvent(new PersonEmailAddressDeletedDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(EmailAddressUpdateCommand command)
        {
            var mail = EmailAddresses.First(e => e.Id == command.Id);

            mail.CopyPropertiesFrom(command);

            base.AddEvent(new PersonEmailAddressUpdateDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(EmailAddressCreateCommand command)
        {
            var mail = new EmailAddress(command);

            this.EmailAddresses.Add(mail);

            base.AddEvent(new PersonUpdatedDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(AddressDeleteCommand command)
        {
            var address = Addresses.First(e => e.Id == command.AddressId);

            this.Addresses.Remove(address);

            base.AddEvent(new PersonAddressDeletedDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(AddressUpdateCommand command)
        {
            var address = Addresses.First(e => e.Id == command.Id);

            address.Take(command);

            base.AddEvent(new PersonAddressUpdateDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(AddressCreateCommand command)
        {
            var address = new PersonAddress(command);

            this.Addresses.Add(address);

            base.AddEvent(new PersonAddressCreateDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(CreditCardCreateCommand command)
        {
            var creditCard = new CreditCard(command);

            this.CreditCards.Add(creditCard);

            base.AddEvent(new PersonCreditCardCreateDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(CreditCardUpdateCommand command)
        {
            var creditCard = this.CreditCards.First(c => c.Id == command.Id);

            creditCard.Take(command);
            
            base.AddEvent(new PersonCreditCardUpdateDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(CreditCardDeactivateCommand command)
        {
            var creditCard = CreditCards.First(c => c.Id == command.CreditCardId);

            creditCard.Take(command);

            base.AddEvent(new PersonCreditCardUpdateDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

        public Person Take(CreditCardDeleteCommand command)
        {
            var creditCard = CreditCards.First(e => e.Id == command.CreditCardId);

            this.CreditCards.Remove(creditCard);

            base.AddEvent(new PersonCreditCardDeleteDomainEvent
            {
                AggregateRootId = Id,
                CommandJson = JsonConvert.SerializeObject(command),
                UserId = command.UserId
            });

            return this;
        }

    }
}