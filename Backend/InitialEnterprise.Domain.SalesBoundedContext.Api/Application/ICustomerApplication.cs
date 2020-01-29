using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.SalesBoundedContext.Api.Application
{
    public interface ICustomerApplication
    {
        Task<IEnumerable<CustomerDto>> Query();

        Task<CustomerDto> Query(Guid id);

        Task<IEnumerable<CustomerDto>> Query(CustomersSearchQueryDto model);

        Task<ICommandHandlerAggregateAnswer> Insert(CustomerDto model);

        Task<ICommandHandlerAggregateAnswer> Update(CustomerDto model);

    }
}
