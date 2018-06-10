using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace InitialEnterprise.Infrastructure.Api.Middlewares
{
    public class AuthenticationByPassMiddleware
    {
        private readonly RequestDelegate requestDelegate;
      
        public AuthenticationByPassMiddleware(RequestDelegate next)
        {
            requestDelegate = next;           
        }

        public async Task Invoke(HttpContext context)
        { 
        }
    }
}
