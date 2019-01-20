using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace InitialEnterprise.Domain.PaymentBoundedContext.PaymentModule.Queries
{
    public class PaymentQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
