using Blazor.Fluxor;
using InitialEnterprise.Shared.Dtos;
using System.Collections.Generic;

namespace InitialEnterprise.Frontend.Store
{
    public class CustomersSearchReducer : Reducer<AppState, CustomersSearchAction>
	{
		public override AppState Reduce(AppState state, CustomersSearchAction action)
		{
			return new AppState(
				searchInProgress: false,
				customers: new List<CustomerDto>(),
				currencies: state.Currencies,
				countries: state.Countries,
				peoples: state.Peoples,
				users: state.Users);
		}		
	}
}
