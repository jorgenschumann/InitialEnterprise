using InitialEnterprise.Domain.SalesBoundedContext.SalesPersonModule.Aggreate;
using InitialEnterprise.Infrastructure.DDD.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Aggreate
{
    public partial class Customer: AggregateRoot
    {       
        [JsonConstructor]
        public Customer()
        {
            //SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [JsonProperty]
        public Guid? PersonId { get; set; }

        [JsonProperty]
        public Guid? StoreId { get; set; }

        [JsonProperty]
        public Guid? TerritoryId { get; set; }

        [JsonProperty]
        public string AccountNumber { get; set; }

        //public virtual Person Person { get; set; }

        //public virtual SalesTerritory SalesTerritory { get; set; }

        //public virtual Store Store { get; set; }

        //public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
