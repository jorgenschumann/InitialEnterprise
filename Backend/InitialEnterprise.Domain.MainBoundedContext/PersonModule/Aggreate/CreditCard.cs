using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class CreditCard: Entity
    {
        private CreditCard()
        {
            PersonCreditCard = new HashSet<PersonCreditCard>();
        }
       
        public string CardType { get; private set; }

        public string CardNumber { get; private set; }

        public byte ExpireMonth { get; private set; }

        public short ExpireYear { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public virtual ICollection<PersonCreditCard> PersonCreditCard { get; private set; }
    }
}