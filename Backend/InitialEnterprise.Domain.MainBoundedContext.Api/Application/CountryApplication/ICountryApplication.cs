using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public interface ICountryApplication
    {
        Task<IEnumerable<CountryDto>> Query();

        Task<CountryDto> Query(Guid id);
    }
}
