namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    partial class HomeTestScenario
    {
        public const string ApiUrlBase = "api/home";

        public static class Get
        {
            public static string Index()
            {
                return $"{ApiUrlBase}";
            }
        }
    }
}