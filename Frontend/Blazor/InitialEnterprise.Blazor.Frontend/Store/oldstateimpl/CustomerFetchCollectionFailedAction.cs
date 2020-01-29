namespace InitialEnterprise.Frontend.Store
{
	public class CustomerFetchCollectionFailedAction
	{
		public string ErrorMessage { get; private set; }

		public CustomerFetchCollectionFailedAction(string errorMessage)
		{
			ErrorMessage = errorMessage;
		}
	}
}
