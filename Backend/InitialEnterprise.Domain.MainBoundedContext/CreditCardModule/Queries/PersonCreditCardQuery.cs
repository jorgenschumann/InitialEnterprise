using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries
{
    public class PersonCreditCardQuery : IQuery
    {
        public Guid PersonId { get; set; }
        public Guid CreditCardId { get; set; }
    }
}
