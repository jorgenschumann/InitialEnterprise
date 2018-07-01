using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Commands;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Infrastructure.Utils;

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

        public Person(CreatePersonCommand command)
        {
            if (command.IsValid)
            {
                this.CopyPropertiesFrom(command);
            }
        }

        public string PersonType { get;  }

        public bool NameStyle { get; }

        public string Title { get;}

        public string FirstName { get;  }

        public string MiddleName { get;  }

        public string LastName { get;  }

        public string Suffix { get;  }

        public int EmailPromotion { get; }

        public virtual ICollection<EmailAddress> EmailAddress { get; private set; }

        public virtual ICollection<PersonCreditCard> PersonCreditCard { get; private set; }

        public virtual ICollection<PersonPhone> PersonPhone { get; private set; }
    }
}
