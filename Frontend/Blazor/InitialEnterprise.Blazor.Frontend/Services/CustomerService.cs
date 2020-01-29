using InitialEnterprise.Frontend.Infrastructure;
using InitialEnterprise.Frontend.Settings;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly IRequestService requestService;
        private readonly ApiSettings apiSettings;

        private readonly string Endpoint = "Customer";

        public CustomerService(IRequestService requestService, ApiSettings apiSettings)
        {
            this.requestService = requestService;
            this.apiSettings = apiSettings;
        }

        public async Task Delete(Guid id)
        {
            await requestService.DeleteAsync<object>(
                $"{apiSettings.SalesUrl}/{Endpoint}/{id}");
        }

        public async Task<IEnumerable<CustomerDto>> Get()
        {
            return await requestService.GetAsync<List<CustomerDto>>(
                 $"{apiSettings.SalesUrl}/{Endpoint}");
        }

        public async Task<CustomerDto> Get(Guid id)
        {
            return await requestService.GetAsync<CustomerDto>
                ($"{apiSettings.SalesUrl}/{Endpoint}/{id}");
        }

        public async Task<IEnumerable<CustomerDto>> Query(CustomersSearchQueryDto query)
        {
            return await requestService.PostAsync<CustomersSearchQueryDto, List<CustomerDto>>(
               $"{apiSettings.SalesUrl}/{Endpoint}/query", query);
        }

        public async Task<CommandHandlerAnswerDto<CustomerDto>> Post(CustomerDto customer)
        {
            return await requestService.PostAsync<CustomerDto, CommandHandlerAnswerDto<CustomerDto>>(
              $"{apiSettings.SalesUrl}/{Endpoint}", customer);
        }


        public async Task<CommandHandlerAnswerDto<CustomerDto>> Put(CustomerDto customer)
        {
            return await requestService.PutAsync<CustomerDto, CommandHandlerAnswerDto<CustomerDto>>(
                $"{apiSettings.SalesUrl}/{Endpoint}/{customer.Id}", customer);
        }
    }
}
