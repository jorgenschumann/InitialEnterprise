using System.Collections.Generic;

namespace InitialEnterprise.Domain.IndentityBoundedContext.Api.Tests.ApiServices
{
    internal static class AuthenticationTestDataSource
    {
        static readonly List<object[]> _loginTestDataCollection = new List<object[]>
                {
                    new object[] {"User1@test.de", "#Az1234567890!", true},
                    new object[] {"UnknownUser@test.de","WrongPassword", false}
                };

        public static IEnumerable<object[]> LoginTestDataCollection
        {
            get { return _loginTestDataCollection; }
        }      
    }
}