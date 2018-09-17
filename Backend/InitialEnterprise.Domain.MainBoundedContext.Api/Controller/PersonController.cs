using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Queries;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    public class PersonController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPersonApplication personApplication;

        public PersonController(IPersonApplication personApplication)
        {
            this.personApplication = personApplication;
        }
               
        [HttpPost]
        [Authorize(Policy = ClaimDefinitions.PersonRead)]
        public async Task<IActionResult> Query([System.Web.Http.FromBody]PersonQuery query)
        {
            var result = (await personApplication.Query(query));

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = ClaimDefinitions.PersonRead)]        
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await personApplication.Query(id);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Policy = ClaimDefinitions.PersonWrite)]
        public async Task<IActionResult> Post([FromBody] PersonDto model)
        {
            var result = await personApplication.Insert(model);

            return Ok(result);
        }


        [HttpPut]
        [Authorize(Policy = ClaimDefinitions.PersonWrite)] 
        public async Task<IActionResult> Put([FromBody] PersonDto model)
        {
            var result = await personApplication.Update(model);

            return Ok(result);
        }
    }
}
