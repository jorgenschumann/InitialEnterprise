using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;
namespace InitialEnterprise.Frontend.Services
{
    public interface ICurrenyService
    {
        Task<IEnumerable<CurrencyDto>> Fetch();
        Task<CurrencyDto> Fetch(Guid id);
    }
}