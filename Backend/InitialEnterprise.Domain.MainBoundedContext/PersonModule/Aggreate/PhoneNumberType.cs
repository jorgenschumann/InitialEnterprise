using System;
using System.Collections.Generic;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PhoneNumberType: Entity
    {
        private PhoneNumberType()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }

        public int PhoneNumberTypeID { get; private set; }
        
        public string Name { get; private set; }

        public DateTime ModifiedDate { get; private set; }
        
        public virtual ICollection<PersonPhone> PersonPhone { get; private set; }
    }
}