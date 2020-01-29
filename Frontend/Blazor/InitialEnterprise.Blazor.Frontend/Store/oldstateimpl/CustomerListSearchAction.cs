using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomerListSearchAction
	{
		public readonly CustomerListSearchQueryDto Query;

		public CustomerListSearchAction(CustomerListSearchQueryDto query)
		{
			Query = query;
		}
	}
}
