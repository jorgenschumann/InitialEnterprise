using InitialEnterprise.Infrastructure.CQRS;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using InitialEnterprise.Shared.Dtos;

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
