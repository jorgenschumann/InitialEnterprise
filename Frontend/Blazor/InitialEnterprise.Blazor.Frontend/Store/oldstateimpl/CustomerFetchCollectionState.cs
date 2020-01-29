using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomerFetchCollectionState
	{
		public bool IsLoading { get; private set; }
		public string ErrorMessage { get; private set; }
		public IEnumerable<CustomerDto> Customers { get; private set; }
		public CustomerDto Customer { get; private set; }

		public CustomerFetchCollectionState(bool isLoading,
			string errorMessage,
			IEnumerable<CustomerDto> customers,
			CustomerDto customer)
		{
			IsLoading = isLoading;
			ErrorMessage = errorMessage;
			Customers = customers;
			Customer = customer;
		}
	}
}
