
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Tests.ApiServices
{


    public partial class UserAccountTestScenario 
    {
        public static class Get
        {
            public const string ApiUrlBase = "api/useraccount";

            public static string UserBy(Guid id) => $"{ApiUrlBase}/{id}";
        }

        public static class Post
        {
            public const string ApiUrlBase = "api/useraccount";

            public static string SignIn = $"{ApiUrlBase}/SignIn";

            public static string Register = $"{ApiUrlBase}/Register";

            public static string Query = $"{ApiUrlBase}";

        }

        public static class Put
        {
            public const string ApiUrlBase = "api/useraccount";

            public static string Update = $"{ApiUrlBase}";
        }
    }
}
