using System;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class EmailAddress: Entity
    {
        private EmailAddress()
        {
        }

        public int EmailAddressID { get; private set; }
        
        public string EmailAddress1 { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public virtual Person Person { get; private set; }
        
    }
}