using Blazor.Fluxor;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomersSuccessActionReducer : Reducer<CustomerFetchCollectionState, CustomerFetchCollectionSuccessAction>
	{
		public override CustomerFetchCollectionState Reduce(CustomerFetchCollectionState state, CustomerFetchCollectionSuccessAction action) =>
			new CustomerFetchCollectionState(
				isLoading: false,
				errorMessage: null,
				customer:null,
				customers: action.Customer);
	}
}
