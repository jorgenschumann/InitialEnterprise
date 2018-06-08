using System;
using InitialEnterprise.Infrastructure.Application;
using InitialEnterprise.Infrastructure.DDD.Annotations;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application
{

    public interface ICurrencyApplication
    {
        CurrencyDto Read(string name);
    }

    [ApplicationServiceAttribute]
    public class CurrencyApplication : ICurrencyApplication
    {
        public CurrencyDto Read(string name)
        {
            throw new NotImplementedException();
        }
    }

    public class CurrencyDto: BaseDataTransferObject
    {
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string IsoCode { get; private set; }

        public string Rate { get; private set; }

    }

}
