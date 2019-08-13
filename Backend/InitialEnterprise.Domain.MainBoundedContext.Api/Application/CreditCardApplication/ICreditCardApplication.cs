using InitialEnterprise.Domain.MainBoundedContext.Api.Application.CreditCardApplication;
using InitialEnterprise.Infrastructure.Application;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface ICreditCardApplication
    {       
        Task<CreditCardDto> Query(Guid creditCardId);

        Task<CreditCardDto> Query(Guid personId, Guid creditCardId);

        Task<ICommandHandlerAnswer> Create(Guid personId, CreditCardDto dto);

        Task<ICommandHandlerAnswer> Update(Guid personId, CreditCardDto dto);

        Task<ICommandHandlerAnswer> Delete(Guid personId, Guid creditCardId);

        Task<IEnumerable<CreditCardTypeDto>> QueryCreditCardTypes();
    }
}
