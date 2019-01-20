using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentApplication;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentsApplication
{
    public class PaymentApplication : IPaymentApplication
    {
        public Task<ICommandHandlerAnswer> Insert(PaymentDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentDto>> Query()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDto> Query(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentDto>> Query(IQuery model)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandHandlerAnswer> Update(PaymentDto model)
        {
            throw new NotImplementedException();
        }
    }
}
