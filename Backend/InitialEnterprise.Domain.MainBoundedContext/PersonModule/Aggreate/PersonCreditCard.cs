using System;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PersonCreditCard : Entity
    {
        private PersonCreditCard()
        {
        }

        public virtual Person Person { get; }

        public virtual CreditCard CreditCard { get; }
    }
}