using System;
using System.Collections.Generic;
using System.Text;


namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{
    partial class CurrencyTestScenario
    {
        public const string ApiUrlBase = "api/currency";

        public static class Get
        {
            public static string GetCurrency(Guid id)
            {
                return $"{ApiUrlBase}/{id}";
            }
        }

        public static class Post
        {
            public static string Currency = $"{ApiUrlBase}/";

            public static string Query = $"{ApiUrlBase}";
        }

        public static class Put
        {
            public static string Currency = $"{ApiUrlBase}/";
        }
    }
}
