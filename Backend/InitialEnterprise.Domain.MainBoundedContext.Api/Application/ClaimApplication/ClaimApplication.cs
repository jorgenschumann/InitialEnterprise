﻿using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.SharedKernel.ClaimDefinitions;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.ClaimApplication
{
    public class ClaimApplication : IClaimApplication
    {
        private readonly IDispatcher dispatcher;

        public ClaimApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<IEnumerable<ClaimRequirementDto>> Query()
        {
            var query = new SharedKernel.ClaimModule.Queries.ClaimQuery();
            var claims = await dispatcher.Query<SharedKernel.ClaimModule.Queries.ClaimQuery, List<ClaimDefinition>>(query);
            return Mapper.Map(claims).ToANew<IEnumerable<ClaimRequirementDto>>();
        }

        public async Task<IEnumerable<ClaimRequirementDto>> Query(IQuery model)
        {
            throw new NotImplementedException();
        }
    }
}