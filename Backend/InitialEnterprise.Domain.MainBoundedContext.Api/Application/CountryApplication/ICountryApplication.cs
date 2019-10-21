using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface ICountryApplication
    {
        Task<IEnumerable<CountryDto>> Query();

        Task<CountryDto> Query(Guid id);
    }
}
