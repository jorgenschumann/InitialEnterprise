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
       
        public string Name { get; }
        
        public virtual ICollection<PersonPhone> PersonPhone { get; private set; }
    }
}