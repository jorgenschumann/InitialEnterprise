﻿using System;
using System.Collections.Generic;

namespace InitialEnterprise.Shared.Dtos
{
    public class CountryDto: DataTransferObject
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public string IsoCode { get; set; }
        public string Code { get; set; }
        public List<string> Provinces { get; set; } = new List<string>();
    }
}