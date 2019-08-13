using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;
using Newtonsoft.Json;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate
{
  
    public class CreditCard : Entity
    {
        [JsonProperty]
        public string CreditCardType { get; private set; }

        [JsonProperty]
        public string CardNumber { get; private set; }

        [JsonProperty]
        public byte ExpireMonth { get; private set; }

        [JsonProperty]
        public short ExpireYear { get; private set; }

        [JsonProperty]
        public Guid PersonId { get; private set; }

        public virtual Person Person { get; private set; }

        [JsonConstructor]
        private CreditCard()
        {
        }

        public CreditCard(CreditCardCreateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }

        public CreditCard(CreditCardUpdateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }

        public CreditCard(CreditCardDeactivateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }
    }
}