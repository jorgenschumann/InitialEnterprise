﻿namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
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
        public static class Put
        {

        }

        public static class Post
        {
            public static string Currency = $"{ApiUrlBase}/";
        }

        public static class Delete
        {

        }
    }
}