using AgileObjects.AgileMapper;
using InitialEnterprise.Domain.MainBoundedContext.Api.Application.PersonApplication;
using InitialEnterprise.Domain.MainBoundedContext.EmailAddressModule.Commands;
using InitialEnterprise.Domain.MainBoundedContext.PersonModule.Aggreate;
using InitialEnterprise.Infrastructure.CQRS;
using InitialEnterprise.Infrastructure.DDD.Domain;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public class EmailAddressApplication : IEmailAddressApplication
    {
        private readonly IDispatcher dispatcher;

        public EmailAddressApplication(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<ICommandHandlerAnswer> Delete(Guid personId, Guid emailAddressId)
        {
            var command = new EmailAddressDeleteCommand
            {
                PersonId = personId,
                MailAddressId = emailAddressId
            };
            return await dispatcher.SendAsync<EmailAddressDeleteCommand, Person>(command);
        }

        public async Task<ICommandHandlerAnswer> Create(Guid personId, EmailAddressDto dto)
        {
            var command = Mapper.Map(dto).OnTo(new EmailAddressCreateCommand());          
            return await dispatcher.SendAsync<EmailAddressCreateCommand, Person>(command);
        }

        public async Task<ICommandHandlerAnswer> Update(Guid personId,EmailAddressDto dto)
        {           
            var command = Mapper.Map(dto).ToANew<EmailAddressUpdateCommand>();
            return await dispatcher.SendAsync<EmailAddressUpdateCommand, Person>(command);
        }
       
    }
}
