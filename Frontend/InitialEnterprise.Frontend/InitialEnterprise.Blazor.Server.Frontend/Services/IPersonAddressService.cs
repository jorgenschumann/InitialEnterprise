using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Blazor.Frontend.Services
{
    public interface IPersonAddressService
    {
        Task<PersonAddressDto> Get(Guid personId, Guid id);

        Task<CommandHandlerAnswerDto<PersonAddressDto>> Put(PersonAddressDto address);

        Task<CommandHandlerAnswerDto<PersonAddressDto>> Post(PersonAddressDto address);

        Task Delete(Guid personId, Guid id);

        Task<List<CountryDto>> GetCountries();

    }
}
