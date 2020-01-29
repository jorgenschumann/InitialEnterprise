
using System;

namespace InitialEnterprise.Shared.Dtos
{
    public class CustomerDto: DataTransferObject
    {
        public Guid Id { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? TerritoryId { get; set; }

        public string AccountNumber { get; set; }
    }
}
