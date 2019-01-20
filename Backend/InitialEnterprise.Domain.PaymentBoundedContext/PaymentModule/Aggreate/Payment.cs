using InitialEnterprise.Infrastructure.DDD.Domain;
using System;

namespace InitialEnterprise.Domain.PaymentBoundedContext.PaymentModule.Aggreate
{
    public class Payment : AggregateRoot
    {       
        public Object Value { get; set; }
    }
}
