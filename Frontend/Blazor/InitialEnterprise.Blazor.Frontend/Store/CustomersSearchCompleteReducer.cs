using Blazor.Fluxor;

namespace InitialEnterprise.Frontend.Store
{
    public class CustomersSearchCompleteReducer : Reducer<AppState, CustomersSearchCompleteAction>
	{
		public override AppState Reduce(AppState state, CustomersSearchCompleteAction action)
		{
			return new AppState(
				searchInProgress: false,
				customers: action.SearchResults,
				currencies: state.Currencies,
				countries: state.Countries,
				peoples: state.Peoples,
				users: state.Users);
		}
	}
}
