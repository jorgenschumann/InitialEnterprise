using InitialEnterprise.Domain.MainBoundedContext.Api.Controller;
using InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentApplication;
using InitialEnterprise.Domain.PaymentBoundedContext.Api.Application.PaymentsApplication;
using InitialEnterprise.Domain.PaymentBoundedContext.PaymentModule.Queries;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.PaymentBoundedContext.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PaymentsController : BaseController
    {
        private readonly IPaymentApplication paymentApplication;

        public PaymentsController(
            IPaymentApplication paymentApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.paymentApplication = paymentApplication;
        }

        [HttpPost]
        [Authorize(Policy = PaymentClaims.PaymentRead)]
        [Route("query")]
        public async Task<IActionResult> Query([FromBody]PaymentQuery query)
        {
            var result = await paymentApplication.Query(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Authorize(Policy = PaymentClaims.PaymentRead)]
        public async Task<IActionResult> Get()
        {
            var result = await paymentApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = PaymentClaims.PaymentRead)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await paymentApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Authorize(Policy = PaymentClaims.PaymentWrite)]
        public async Task<IActionResult> Post([FromBody] PaymentDto model)
        {
            var result = await paymentApplication.Insert(model);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPut]
        [Authorize(Policy = PaymentClaims.PaymentWrite)]
        public async Task<IActionResult> Put([FromBody] PaymentDto model)
        {
            var result = await paymentApplication.Update(model);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}