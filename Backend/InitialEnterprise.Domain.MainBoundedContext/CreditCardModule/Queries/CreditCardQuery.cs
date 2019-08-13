using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries
{

    public class CreditCardQuery : IQuery
    {
        public Guid CreditCardId { get; set; }
    }
}
