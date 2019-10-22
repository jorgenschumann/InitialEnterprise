using InitialEnterprise.Domain.MainBoundedContext.Api.ActionFilter;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Web.Http;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [InjectUserId]
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