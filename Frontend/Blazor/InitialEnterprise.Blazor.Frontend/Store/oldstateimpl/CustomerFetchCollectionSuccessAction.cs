using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomerFetchCollectionSuccessAction 
	{
		public IEnumerable<CustomerDto> Customer { get; private set; }

		public CustomerFetchCollectionSuccessAction(IEnumerable<CustomerDto> customer)
		{
			Customer = customer;
		}
	}	
}
