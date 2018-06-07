namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests
{
    public class CurrencyTestScenariosBase : TestScenariosBase
    {
        private const string ApiUrlBase = "api/currency";
                        
        public static class Get
        {
            public static string GetCurrency(int id)
            {
                return $"{ApiUrlBase}/{id}";
            }
        }

        public static class Post
        {
            public static string Currency = $"{ApiUrlBase}/";
        }
    }
}