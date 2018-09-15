﻿using InitialEnterprise.Infrastructure.DDD.Command;

namespace InitialEnterprise.Domain.MainBoundedContext.CurrencyModule.Commands
{
    public class SignInCommand : DomainCommand
    {   
        public string Email { get; set; }

        public string Password { get; set; }    
        
        public bool Remember { get; set; }
    }
}