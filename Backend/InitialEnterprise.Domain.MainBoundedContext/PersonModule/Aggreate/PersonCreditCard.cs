using System;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PersonCreditCard: Entity
    {
        private PersonCreditCard()
        {
        }

        public DateTime ModifiedDate { get; private set; }

        public virtual Person Person { get; private set; }

        public virtual CreditCard CreditCard { get; private set; }
    }
}