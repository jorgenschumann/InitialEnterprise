using System;

namespace InitialEnterprise.Shared.Dtos
{
    public class UserRegisterDto
    {    
        public string FirstName { get; set; }
              
        public string LastName { get; set; }
             
        public DateTime DateOfBirth { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}