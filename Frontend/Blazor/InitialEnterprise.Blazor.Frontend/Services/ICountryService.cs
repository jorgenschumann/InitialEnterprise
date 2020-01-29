using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Services
{
    public interface ICountryService
    {
        Task<List<CountryDto>> Get();
    }
}