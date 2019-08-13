using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Repository;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.AddressModule.QueryHandler
{
    public class AddressQueryHandler :
      IQueryHandlerAsync<AddressQuery, PersonAddress>
    {
        private readonly IAddressRepository addressRepository;
        public AddressQueryHandler(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<PersonAddress> Retrieve(AddressQuery query)
        {
            return await addressRepository.Query(query);
        }    
    }
}
