﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.UserManagerApplication
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        
        public string EmailConfirmed { get; set; }
               
        public string PhoneNumber { get; set; }
              
        public string PhoneNumberConfirmed { get; set; }
               
        public string Password { get; set; }
               
        public string ConfirmPassword { get; set; }
        
        public IEnumerable<ApplicationUserClaimDto> Claims { get; set; }    
    }

    public class ApplicationUserClaimDto
    {       
        public virtual int Id { get; set; }
          
        public virtual string ClaimType { get; set; }
      
        public virtual string ClaimValue { get; set; }
    }


    public class UserSignInResultDto
    {
        public SignInResult SignInResult { get; set; }
        public UserDto User { get; set; }
        public String Token { get; set; }
    }
}