using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface ICreditCardApplication
    {       
        Task<CreditCardDto> Query(Guid creditCardId);

        Task<CreditCardDto> Query(Guid personId, Guid creditCardId);

        Task<ICommandHandlerAggregateAnswer> Create(Guid personId, CreditCardDto dto);

        Task<ICommandHandlerAggregateAnswer> Update(Guid personId, CreditCardDto dto);

        Task<ICommandHandlerAggregateAnswer> Delete(Guid personId, Guid creditCardId);

        Task<IEnumerable<CreditCardTypeDto>> QueryCreditCardTypes();
    }
}
