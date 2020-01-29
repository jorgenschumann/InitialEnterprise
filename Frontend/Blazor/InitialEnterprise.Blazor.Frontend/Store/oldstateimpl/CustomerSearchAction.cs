using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Frontend.Store
{
    public class CustomerSearchAction
	{
		public readonly CustomerSearchQueryDto Query;

		public CustomerSearchAction(CustomerSearchQueryDto query)
		{
			Query = query;
		}
	}
}
