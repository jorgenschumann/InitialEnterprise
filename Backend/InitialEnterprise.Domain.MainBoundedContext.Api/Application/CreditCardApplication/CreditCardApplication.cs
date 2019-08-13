using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.CreditCardApplication;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public class CreditCardApplication : ICreditCardApplication
    {
        private readonly IDispatcher dispatcher;

        public CreditCardApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<ICommandHandlerAnswer> Create(Guid personId, CreditCardDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandHandlerAnswer> Delete(Guid personId, Guid creditCardId)
        {
            throw new NotImplementedException();
        }

        public async Task<CreditCardDto> Query(Guid personId, Guid creditCardId)
        {
            var query = new PersonCreditCardQuery { PersonId = personId, CreditCardId = creditCardId };
            var creditCard = await dispatcher.GetResultAsync<PersonCreditCardQuery, CreditCard>(query);
            return Mapper.Map(creditCard).ToANew<CreditCardDto>();
        }

        public async Task<CreditCardDto> Query(Guid creditCardId)
        {
            var query = new CreditCardQuery { CreditCardId = creditCardId };
            var creditCard = await dispatcher.GetResultAsync<CreditCardQuery, CreditCard>(query);
            return Mapper.Map(creditCard).ToANew<CreditCardDto>();
        }

        public async Task<IEnumerable<CreditCardTypeDto>> QueryCreditCardTypes()
        {
            var query = new CreditCardTypeQuery ();
            var creditCard = await dispatcher.GetResultAsync<CreditCardTypeQuery, IEnumerable<CreditCardType>>(query);
            return Mapper.Map(creditCard).ToANew<IEnumerable<CreditCardTypeDto>>();
        }

        public async Task<ICommandHandlerAnswer> Update(Guid personId, CreditCardDto dto)
        { 
            throw new NotImplementedException();
        }

        //public async Task<CreditCardDto> Query(Guid personId, Guid creditCardId)
        //{
        //    var query = new AddressQuery { PersonId = personId, AddressId = addressId };
        //    var address = await dispatcher.GetResultAsync<AddressQuery, PersonAddress>(query);
        //    return Mapper.Map(address).ToANew<PersonAddressDto>();
        //}

        //public async Task<ICommandHandlerAnswer> Create(Guid personId, PersonAddressDto dto)
        //{
        //    var command = Mapper.Map(dto).OnTo(new AddressCreateCommand());
        //    return await dispatcher.SendAsync<AddressCreateCommand, Person>(command);
        //}

        //public async Task<ICommandHandlerAnswer> Delete(Guid personId, Guid addressId)
        //{
        //    var command = new AddressDeleteCommand
        //    {
        //        PersonId = personId,
        //        AddressId = addressId
        //    };
        //    return await dispatcher.SendAsync<AddressDeleteCommand, Person>(command);
        //}

        //public async Task<ICommandHandlerAnswer> Update(Guid personId, PersonAddressDto dto)
        //{
        //    var command = Mapper.Map(dto).ToANew<AddressUpdateCommand>();
        //    return await dispatcher.SendAsync<AddressUpdateCommand, Person>(command);
        //}
    }
}
