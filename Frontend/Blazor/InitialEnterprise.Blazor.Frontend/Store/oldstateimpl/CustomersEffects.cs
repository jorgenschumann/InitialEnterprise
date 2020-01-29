using Blazor.Fluxor;
using InitialEnterprise.Frontend.Services;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace InitialEnterprise.Frontend.Store
{
	public class CustomersEffects : Effect<CustomerListSearchAction>
	{
		private readonly ICustomerService customerService;

		public CustomersEffects(ICustomerService customerService)
		{
			this.customerService = customerService;
		}

		protected override async Task HandleAsync(CustomerListSearchAction action, IDispatcher dispatcher)
		{
			try
			{
				IEnumerable<CustomerDto> searchResults = await customerService.Query(action.Query);
				dispatcher.Dispatch(new CustomerFetchCollectionSuccessAction(searchResults));
			}
			catch
			{
				dispatcher.Dispatch(new CustomerFetchCollectionSuccessAction(null));
			}
		}
	}
}
