using System;

namespace InitialEnterprise.Shared.Dtos
{
    public class EmailAddressDto : DataTransferObject
    {
        public Guid Id { get; set; }

        public string MailAddress { get; set; }

        public string MailAddressType { get; set; }

        public bool IsPrimary { get; set; }

        public Guid PersonId { get; set; }
    }
}