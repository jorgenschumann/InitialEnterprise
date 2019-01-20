namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Tests.ApiControllers
{
    partial class HomeTestScenario
    {
        public const string ApiUrlBase = "api/home";

        public static class Get
        {
            public static string GetIndex()
            {
                return $"{ApiUrlBase}";
            }
        }
    }
}