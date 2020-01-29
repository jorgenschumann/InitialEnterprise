using Blazor.Fluxor;
using InitialEnterprise.Frontend.Services;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Store
{
    public class CustomersSearchEffect: Effect<CustomersSearchAction>
	{
		private readonly ICustomerService customerService;

		public CustomersSearchEffect(ICustomerService customerService)
		{
			this.customerService = customerService;
		}

		protected override async Task HandleAsync(CustomersSearchAction action, IDispatcher dispatcher)
		{
			var searchResults = await customerService.Query(action.Query);
			dispatcher.Dispatch(new CustomersSearchCompleteAction(searchResults));
		}
	}
}
