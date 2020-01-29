using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InitialEnterprise.Infrastructure.Api
{
    //[InjectUserId]
    [Authorize]
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal userPrinzipal;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            if (httpContextAccessor.HttpContext?.User != null)
            {
                userPrinzipal = httpContextAccessor.HttpContext.User;
            }
        }
    }
}