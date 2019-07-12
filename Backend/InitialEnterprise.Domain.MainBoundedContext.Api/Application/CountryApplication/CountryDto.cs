using InitialEnterprise.Infrastructure.Application;
using System;
using System.Collections.Generic;

namespace InitialEnterprise.Domain.MainBoundedContext.Api.Application.EmailAddressApplication
{
    public class CountryDto: DataTransferObject
    {
        public Guid Id { get; set; }

        public string Name{ get; set; }

        public List<string> Provinces { get; set; } = new List<string>();
    }
}