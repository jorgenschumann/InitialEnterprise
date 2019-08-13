using InitialEnterprise.Domain.MainBoundedContext.Api.Application.CreditCardApplication;
using InitialEnterprise.Infrastructure.Application;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public class PersonDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public string PersonType { get; set; }

        public bool NameStyle { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int EmailPromotion { get; set; }

        public ICollection<EmailAddressDto> EmailAddresses { get; set; }

        public ICollection<PersonAddressDto> Addresses { get; set; }

        public ICollection<CreditCardDto> CreditCards { get; set; }
    }
}