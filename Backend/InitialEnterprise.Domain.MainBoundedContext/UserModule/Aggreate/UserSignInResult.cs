using Microsoft.AspNetCore.Identity;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.UserModule.Aggreate
{ 
    public class UserSignInResult
    {
        public SignInResult SignInResult { get; set; }
        public ApplicationUser User { get; set; }
        public String Token { get; set; }      
    }
}
