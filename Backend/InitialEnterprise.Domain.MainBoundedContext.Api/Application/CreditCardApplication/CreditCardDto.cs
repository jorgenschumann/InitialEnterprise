using InitialEnterprise.Infrastructure.Application;
using System;
namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.CreditCardApplication
{
    public class CreditCardDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public string CreditCardType { get; set; }

        public string CardNumber { get; set; }

        public byte ExpireMonth { get; set; }

        public short ExpireYear { get; set; }

        public Guid PersonId { get; set; }
    }
}
