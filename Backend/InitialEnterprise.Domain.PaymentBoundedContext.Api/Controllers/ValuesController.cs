using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> Get()
        {
            return new[] {
                new Currency { Name="foo1", Value="bar1"},
                new Currency { Name="foo2", Value="bar2"}
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Currency
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}