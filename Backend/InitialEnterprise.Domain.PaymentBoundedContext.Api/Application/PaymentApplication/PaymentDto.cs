using InitialEnterprise.Infrastructure.Application;
using System;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentApplication
{
    public class PaymentDto : DataTransferObject
    {
        public Object Value { get; set; }
    }
}
