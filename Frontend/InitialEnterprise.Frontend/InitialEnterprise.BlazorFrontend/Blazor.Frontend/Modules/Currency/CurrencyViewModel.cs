using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Frontend.Modules.Currency
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

    }
}
