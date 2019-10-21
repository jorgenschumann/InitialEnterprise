using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.AddressModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Domain;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public class AddressApplication : IAddressApplication
    {
        private readonly IDispatcher dispatcher;

        public AddressApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<PersonAddressDto> Query(Guid personId, Guid addressId)
        {
            var query = new AddressQuery { PersonId = personId, AddressId = addressId };
            var address = await dispatcher.Query<AddressQuery, PersonAddress>(query);
            return Mapper.Map(address).ToANew<PersonAddressDto>();
        }

        public async Task<ICommandHandlerAggregateAnswer> Create(Guid personId, PersonAddressDto dto)
        {
            var command = Mapper.Map(dto).OnTo(new AddressCreateCommand());
            return await dispatcher.Send<AddressCreateCommand, Person>(command);
        }

        public async Task<ICommandHandlerAggregateAnswer> Delete(Guid personId, Guid addressId)
        {
            var command = new AddressDeleteCommand
            {
                PersonId = personId,
                AddressId = addressId
            };
            return await dispatcher.Send<AddressDeleteCommand, Person>(command);
        }

        public async Task<ICommandHandlerAggregateAnswer> Update(Guid personId, PersonAddressDto dto)
        {
            var command = Mapper.Map(dto).ToANew<AddressUpdateCommand>();
            return await dispatcher.Send<AddressUpdateCommand, Person>(command);
        }
    }
}
