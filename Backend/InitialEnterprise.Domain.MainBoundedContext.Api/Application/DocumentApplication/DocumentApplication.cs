using InitialEnterprise.Domain.MainBoundedContext.Api.Shared;
using InitialEnterprise.Infrastructure.CQRS;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.DocumentApplication
{
    public class DocumentApplication
    {
        private readonly IDispatcher dispatcher;

        public DocumentApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<CommandHandlerAnswerDto<IFormFile>> Insert(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
