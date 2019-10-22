using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands;
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
            CardNumber = command.CardNumber;
            CreditCardType = command.CreditCardType.Name;
            ExpireMonth = command.ExpireMonth;
            ExpireYear = command.ExpireYear;
            PersonId = command.PersonId;
        }

        public void Take(CreditCardUpdateCommand command)
        {
            CardNumber = command.CardNumber;
            CreditCardType = command.CreditCardType.Name;
            ExpireMonth = command.ExpireMonth;
            ExpireYear = command.ExpireYear;
        }           

        public void Take(CreditCardDeactivateCommand command)
        {
            this.CopyPropertiesFrom(command);
        }
    }
}