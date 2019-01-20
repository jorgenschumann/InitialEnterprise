using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IPersonApplication personApplication;

        public PersonController(
            IPersonApplication personApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.personApplication = personApplication;
        }

        [HttpPost]
        [Route("query")]
        [Authorize(Policy = PersonClaims.PersonRead)]
        public async Task<IActionResult> Query([System.Web.Http.FromBody]PersonQuery query)
        {
            var result = await personApplication.Query(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Authorize(Policy = PersonClaims.PersonRead)]
        public async Task<IActionResult> Get()
        {
            var result = await personApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = PersonClaims.PersonRead)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await personApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Authorize(Policy = PersonClaims.PersonWrite)]
        public async Task<IActionResult> Post([FromBody] PersonDto model)
        {
            var result = await personApplication.Insert(model);
            return Ok(result);// return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPut]
        [Authorize(Policy = PersonClaims.PersonWrite)]
        public async Task<IActionResult> Put([FromBody] PersonDto model)
        {
            var result = await personApplication.Update(model);
            return Ok(result);// result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}