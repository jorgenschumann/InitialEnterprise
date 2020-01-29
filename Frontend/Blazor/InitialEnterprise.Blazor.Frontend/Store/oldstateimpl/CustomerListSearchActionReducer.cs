using Blazor.Fluxor;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomerListSearchActionReducer 
		: Reducer<CustomerFetchCollectionState, CustomerListSearchAction>
	{
		public override CustomerFetchCollectionState Reduce(CustomerFetchCollectionState state, CustomerListSearchAction action) =>
			new CustomerFetchCollectionState(
				isLoading: true,
				errorMessage: null,
				customers: null,
				customer: state.Customer);
	}

	public class CustomerSearchActionReducer
		: Reducer<CustomerFetchCollectionState, CustomerSearchAction>
	{
		public override CustomerFetchCollectionState Reduce(CustomerFetchCollectionState state, CustomerSearchAction action) =>
			new CustomerFetchCollectionState(
				isLoading: true,
				errorMessage: null,
				customers: state.Customers,
				customer:null);
	}
}
