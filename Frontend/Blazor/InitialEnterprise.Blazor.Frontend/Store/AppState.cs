using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace InitialEnterprise.Frontend.Store
{
    public class AppState
    {
		public bool SearchInProgress { get; private set; }
		public CurrencyDto[] Currencies { get; private set; }
		public CustomerDto[] Customers { get; private set; }
		public CountryDto[] Countries { get; private set; }
		public PersonDto[] Peoples { get; private set; }
		public UserDto[] Users { get; private set; }

		public AppState()
		{
			Currencies = Array.Empty<CurrencyDto>();
			Customers = Array.Empty<CustomerDto>();
			Countries = Array.Empty<CountryDto>();
			Peoples = Array.Empty<PersonDto>();
			Users = Array.Empty<UserDto>();
		}

		public AppState(bool searchInProgress,
			IEnumerable<CurrencyDto> currencies,
			IEnumerable<CustomerDto> customers, 
			IEnumerable<CountryDto> countries, 
			IEnumerable<PersonDto> peoples,
			IEnumerable<UserDto> users)
		{
			SearchInProgress = searchInProgress;
			Currencies = currencies?.ToArray() ?? Array.Empty<CurrencyDto>();
			Customers = customers?.ToArray() ?? Array.Empty<CustomerDto>();
			Countries = countries?.ToArray() ?? Array.Empty<CountryDto>();
			Peoples = peoples?.ToArray() ?? Array.Empty<PersonDto>();
			Users = users?.ToArray() ?? Array.Empty<UserDto>();
		}
	}
}
