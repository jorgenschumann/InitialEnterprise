﻿using InitialEnterprise.Frontend.Services;
using InitialEnterprise.Frontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Pages.Person.MailAddress
{
    public class EmailAddressController
    {
        private readonly IEmailAddressService emailAddressService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;


        public EmailAddressController(
            IEmailAddressService emailAddressService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService

            )
        {
            this.emailAddressService = emailAddressService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;
        }


        public async Task<EmailAddressDto> Get(Guid personId, Guid id)
        {
            using (busyIndicatorService.Show())
            {
                return await emailAddressService.Get(personId, id);
            }
        }

        public async Task Delete(Guid personId, Guid id)
        {
            using (busyIndicatorService.Show())
            {
                await emailAddressService.Delete(personId, id);
            }
        }

        public async Task<CommandHandlerAnswerDto<EmailAddressDto>> Save(EmailAddressDto mail)
        {
            using (busyIndicatorService.Show())
            {
                if (mail.Id != Guid.Empty)
                {
                    return await emailAddressService.Put(mail);
                }
                return await emailAddressService.Post(mail);
            }
        }
    }
}