using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Frontend.Store
{
	public class CustomersSearchAction
	{
		public readonly CustomersSearchQueryDto Query;

		public CustomersSearchAction(CustomersSearchQueryDto query)
		{
			Query = query;
		}
	}
}
