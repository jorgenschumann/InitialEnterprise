using System;

namespace InitialEnterprise.Shared.Dtos
{
    public class CreditCardDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public string CreditCardHolderName { get; set; }

        public string CreditCardType { get; set; }

        public string CardNumber { get; set; }

        public byte ExpireMonth { get; set; }

        public short ExpireYear { get; set; }

        public Guid PersonId { get; set; }
    }
}
