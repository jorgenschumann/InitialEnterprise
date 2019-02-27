using Microsoft.AspNetCore.Mvc;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    //[Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Index()
        {
            return Ok(nameof(HomeController));
        }
    }
}