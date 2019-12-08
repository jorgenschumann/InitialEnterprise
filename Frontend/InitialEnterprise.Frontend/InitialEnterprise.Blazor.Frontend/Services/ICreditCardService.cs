using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public interface ICreditCardService
    {
        Task<CreditCardDto> Get(Guid personId, Guid id);

        Task<CommandHandlerAnswerDto<CreditCardDto>> Put(CreditCardDto card);

        Task<CommandHandlerAnswerDto<CreditCardDto>> Post(CreditCardDto card);

        Task Delete(Guid personId, Guid id);

        Task<List<CreditCardTypeDto>> GetCreditCardTypes();
        
    }
    
}
