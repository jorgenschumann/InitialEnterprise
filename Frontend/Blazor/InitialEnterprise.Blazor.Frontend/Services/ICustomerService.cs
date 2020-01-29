using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> Get();

        Task<CustomerDto> Get(Guid id);

        Task<IEnumerable<CustomerDto>> Query(CustomersSearchQueryDto query);
    
        Task<CommandHandlerAnswerDto<CustomerDto>> Put(CustomerDto user);

        Task<CommandHandlerAnswerDto<CustomerDto>> Post(CustomerDto user);

        Task Delete(Guid id);
    }
}
