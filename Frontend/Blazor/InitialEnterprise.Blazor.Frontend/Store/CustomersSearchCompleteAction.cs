using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Store
{
    public class CustomersSearchCompleteAction
	{
		public readonly IEnumerable<CustomerDto> SearchResults;

		public CustomersSearchCompleteAction(IEnumerable<CustomerDto> searchResults)
		{
			SearchResults = searchResults ?? Array.Empty<CustomerDto>();
		}
	}
}
