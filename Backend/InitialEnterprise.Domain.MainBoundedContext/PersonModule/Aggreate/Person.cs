using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate
{
    public class Person : AggregateRoot
    {
        private Person()
        {
            EmailAddress = new HashSet<EmailAddress>();
            PersonCreditCard = new HashSet<PersonCreditCard>();
            PersonPhone = new HashSet<PersonPhone>();
        }

        public string PersonType { get; private set; }

        public bool NameStyle { get; private set; }

        public string Title { get; private set; }
        
        public string FirstName { get; private set; }
        
        public string MiddleName { get; private set; }
        
        public string LastName { get; private set; }
        
        public string Suffix { get; private set; }

        public int EmailPromotion { get; private set; }

        public DateTime ModifiedDate { get; private set; }
        
        public virtual ICollection<EmailAddress> EmailAddress { get; private set; }
        
        public virtual ICollection<PersonCreditCard> PersonCreditCard { get; private set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; private  set; }
    }
}
