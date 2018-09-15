using InitialEnterprise.Infrastructure.DDD.Domain;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PersonPhone : Entity
    {
        private PersonPhone()
        {
        }

        public string PhoneNumber { get; }

        public DateTime ModifiedDate { get; }

        public virtual Person Person { get; }

        public Guid PhoneNumberTypeID { get; }

        public virtual PhoneNumberType PhoneNumberType { get; }
    }
}