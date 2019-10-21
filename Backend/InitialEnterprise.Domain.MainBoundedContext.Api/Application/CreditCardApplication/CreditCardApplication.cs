using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Aggreate;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.CreditCardModule.Queries;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public class CreditCardApplication : ICreditCardApplication
    {
        private readonly IDispatcher dispatcher;

        public CreditCardApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }
        public async Task<CreditCardDto> Query(Guid personId, Guid creditCardId)
        {
            var query = new PersonCreditCardQuery { PersonId = personId, CreditCardId = creditCardId };
            var creditCard = await dispatcher.Query<PersonCreditCardQuery, CreditCard>(query);
            return Mapper.Map(creditCard).ToANew<CreditCardDto>();
        }

        public async Task<CreditCardDto> Query(Guid creditCardId)
        {
            var query = new CreditCardQuery { CreditCardId = creditCardId };
            var creditCard = await dispatcher.Query<CreditCardQuery, CreditCard>(query);
            return Mapper.Map(creditCard).ToANew<CreditCardDto>();
        }

        public async Task<IEnumerable<CreditCardTypeDto>> QueryCreditCardTypes()
        {
            var query = new CreditCardTypeQuery();
            var creditCard = await dispatcher.Query<CreditCardTypeQuery, IEnumerable<CreditCardType>>(query);
            return Mapper.Map(creditCard).ToANew<IEnumerable<CreditCardTypeDto>>();
        }

        public async Task<ICommandHandlerAggregateAnswer> Update(Guid personId, CreditCardDto dto)
        {
            var command = Mapper.Map(dto).ToANew<CreditCardUpdateCommand>
                (cfg => cfg.Map((p, d) => CreditCardType.FromName(p.CreditCardType)).To(d => d.CreditCardType));
            return await dispatcher.Send<CreditCardUpdateCommand, Person>(command);
        }

        public async Task<ICommandHandlerAggregateAnswer> Create(Guid personId, CreditCardDto dto)
        {
            var command = Mapper.Map(dto).OnTo(new CreditCardCreateCommand());
            command.CreditCardType = CreditCardType.FromName(dto.CreditCardType);
            return await dispatcher.Send<CreditCardCreateCommand, Person>(command);
        }

        public async Task<ICommandHandlerAggregateAnswer> Delete(Guid personId, Guid creditCardId)
        {
            var command = new CreditCardDeleteCommand { PersonId = personId, CreditCardId = creditCardId };
            return await dispatcher.Send<CreditCardDeleteCommand, Person>(command);
        }
    }
}
