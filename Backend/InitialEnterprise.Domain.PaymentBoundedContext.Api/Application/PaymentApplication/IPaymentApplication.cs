using InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentApplication;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentsApplication
{
    public interface IPaymentApplication
    {
        Task<IEnumerable<PaymentDto>> Query();

        Task<PaymentDto> Query(Guid id);

        Task<IEnumerable<PaymentDto>> Query(IQuery model);

        Task<ICommandHandlerAnswer> Insert(PaymentDto model);

        Task<ICommandHandlerAnswer> Update(PaymentDto model);
    }
}
