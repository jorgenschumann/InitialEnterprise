using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public interface ICurrencyService
    {
        Task<List<CurrencyDto>> Fetch();

        Task<CurrencyDto> Fetch(Guid id);

        Task<CommandHandlerAnswerDto<CurrencyDto>> Post(CurrencyDto currency);

        Task<CommandHandlerAnswerDto<CurrencyDto>> Put(CurrencyDto currency);

        Task Delete(Guid id);
    }
}
