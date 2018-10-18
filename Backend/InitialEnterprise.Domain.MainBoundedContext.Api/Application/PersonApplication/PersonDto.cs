using InitialEnterprise.Infrastructure.Application;
using System;

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

    }
}
