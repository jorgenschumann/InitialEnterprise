using InitialEnterprise.Frontend.Services;
using InitialEnterprise.Frontend.UiServices;
using InitialEnterprise.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.Pages.Person.CreditCard
{
    public class CreditCardController
    {
        private readonly ICreditCardService creditCardService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IBusyIndicatorService busyIndicatorService;
      

        public CreditCardController(
            ICreditCardService creditCardService,
            IMessageBoxService messageBoxService,
            IBusyIndicatorService busyIndicatorService
          
            )
        {
            this.creditCardService = creditCardService;
            this.messageBoxService = messageBoxService;
            this.busyIndicatorService = busyIndicatorService;          
        }               

        public async Task<CreditCardDto> Get(Guid personId, Guid id)
        {
            using (busyIndicatorService.Show())
            {
                return await creditCardService.Get(personId, id);
            }
        }

        public async Task Delete(Guid personId, Guid id)
        {
            using (busyIndicatorService.Show())
            {
                await creditCardService.Delete(personId, id);             
            }
        }

        public async Task<CommandHandlerAnswerDto<CreditCardDto>> Save(CreditCardDto card)
        {
            using (busyIndicatorService.Show())
            {
                if (card.Id != Guid.Empty)
                {
                    return await creditCardService.Put(card);
                }
                return await creditCardService.Post(card);
            }
        }

        public async Task<List<CreditCardTypeDto>> GetCreditCardTypes()
        {
            using (busyIndicatorService.Show())
            {
                return await creditCardService.GetCreditCardTypes();
            }
        }
    }
}