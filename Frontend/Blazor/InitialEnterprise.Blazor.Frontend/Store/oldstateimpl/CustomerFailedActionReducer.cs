using Blazor.Fluxor;

namespace InitialEnterprise.Frontend.Store
{
	public class GetCustomerFailedActionReducer : Reducer<CustomerFetchCollectionState, CustomerFetchCollectionFailedAction>
	{
		public override CustomerFetchCollectionState Reduce(CustomerFetchCollectionState state, CustomerFetchCollectionFailedAction action) =>
			new CustomerFetchCollectionState(
				isLoading: false,
				errorMessage: action.ErrorMessage,
				customer: null,
				customers: null);
	}
}
