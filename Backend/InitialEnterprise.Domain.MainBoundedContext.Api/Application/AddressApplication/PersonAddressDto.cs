using InitialEnterprise.Infrastructure.Application;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication
{
    public class PersonAddressDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public bool IsPrimary { get; set; }
    }
}