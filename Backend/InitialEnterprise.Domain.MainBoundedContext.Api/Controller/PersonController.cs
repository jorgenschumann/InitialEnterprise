﻿using InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication;
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
        private readonly IEmailAddressApplication emailAddressApplication;
        private readonly IAddressApplication addressApplication;

        public PersonController(
            IPersonApplication personApplication,
            IEmailAddressApplication emailAddressApplication,
            IAddressApplication addressApplication,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.personApplication = personApplication;
            this.emailAddressApplication = emailAddressApplication;
            this.addressApplication = addressApplication;
        }

        [HttpPost]
        [Route("query")]
        [Authorize(Policy = PersonReadClaim.PolicyName)]
        public async Task<IActionResult> Query([System.Web.Http.FromBody]PersonQuery query)
        {
            var result = await personApplication.Query(query);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Authorize(Policy = PersonQueryClaim.PolicyName)]
        public async Task<IActionResult> Get()
        {
            var result = await personApplication.Query();
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        [Authorize(Policy = PersonReadClaim.PolicyName)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await personApplication.Query(id);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> Post([FromBody] PersonDto dto)
        {
            var result = await personApplication.Insert(dto);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PersonDto dto)
        {
            var result = await personApplication.Update(dto);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{personId}/emailaddresses/{mailAddressId}")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> GetMail(Guid personId, Guid mailAddressId)
        {
            var result = await emailAddressApplication.Delete(personId, mailAddressId);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete("{personId}/emailaddresses/{mailAddressId}")]       
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> DeleteMail(Guid personId, Guid mailAddressId)
        {
           var result = await emailAddressApplication.Delete(personId, mailAddressId);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPut("{personId}/emailaddresses")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> PutMail(Guid personId, [FromBody] EmailAddressDto dto)
        {
            var result = await emailAddressApplication.Update(personId, dto);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpPost("{personId}/emailaddresses")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> PostMail(Guid personId, [FromBody] EmailAddressDto dto)
        {
            var result = await emailAddressApplication.Create(personId, dto);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpGet("{personId}/addresses/{addressId}")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> GetAddress(Guid personId, Guid addressId)
        {
            var result = await addressApplication.Query(personId, addressId);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPut("{personId}/addresses")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> PutAddress(Guid personId, [FromBody] PersonAddressDto dto)
        {
            var result = await addressApplication.Update(personId, dto);
            return result.IsNotNull() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost("{personId}/addresses")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> PostAddress(Guid personId, [FromBody] PersonAddressDto dto)
        {
            var result = await addressApplication.Create(personId, dto);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete("{personId}/addresses/{addressId}")]
        [Authorize(Policy = PersonWriteClaim.PolicyName)]
        public async Task<IActionResult> DeleteAddress(Guid personId, Guid addressId)
        {
            var result = await addressApplication.Delete(personId, addressId);
            return result.ValidationResult.IsValid ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}