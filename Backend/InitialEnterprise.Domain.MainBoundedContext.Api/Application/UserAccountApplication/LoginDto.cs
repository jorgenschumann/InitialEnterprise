using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public class UserLoginDto
    {        
        public string Email { get; set; }    
        
        public string Password { get; set; }
              
        public bool RememberMe { get; set; } = false;
    }
}