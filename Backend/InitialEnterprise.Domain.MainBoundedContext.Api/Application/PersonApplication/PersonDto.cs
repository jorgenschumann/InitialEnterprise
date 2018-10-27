using InitialEnterprise.Infrastructure.Application;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public class PersonDto: DataTransferObject
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string PersonType { get; }
        public bool NameStyle { get; }
        public string Title { get; }
        public string MiddleName { get; }
        public string Suffix { get; }
        public int EmailPromotion { get; }
        public virtual ICollection<EmailAddressDto> EmailAddresses { get; set; }
    }


    public class EmailAddressDto
    {
        public Guid Id { get; set; }

        public string MailAddress { get; set; }

        public Guid PersonId { get; set; }
    }  
}
