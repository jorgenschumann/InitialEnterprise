using Blazor.Fluxor;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomerFetchCollectionFeature : Feature<CustomerFetchCollectionState>
	{
		public override string GetName() => "CustomerFetchCollectionState";

		protected override CustomerFetchCollectionState GetInitialState() => new CustomerFetchCollectionState(
			isLoading: false,
			errorMessage: null,
			customers: null,
			customer:null);
	}
}
