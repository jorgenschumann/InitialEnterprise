using InitialEnterprise.Infrastructure.CQRS.Queries;

namespace InitialEnterprise.Domain.SalesBoundedContext.SalesCustomerModule.Queries
{
    public class CustomerSeachQuery : IQuery
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
