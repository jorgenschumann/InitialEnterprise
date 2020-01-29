using InitialEnterprise.Infrastructure.DDD.Domain;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class PhoneNumberType : Entity
    {
        public PhoneNumberType()
        {           
        }

        public string Name { get; }

        public virtual ICollection<PersonPhone> PersonPhone { get; private set; } = new HashSet<PersonPhone>();
    }
}