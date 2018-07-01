using System;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PersonPhone: Entity
    {
        private PersonPhone()
        {
        }

        public string PhoneNumber { get; private set; }
        
        public int PhoneNumberTypeID { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public virtual Person Person { get; private set; }

        public virtual PhoneNumberType PhoneNumberType { get; private set; }
    }
}