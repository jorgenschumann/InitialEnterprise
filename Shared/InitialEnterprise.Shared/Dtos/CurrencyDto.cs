using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitialEnterprise.Shared.Dtos
{
    public class CurrencyDto : DataTransferObject
    {
        public Guid Id { get; set; }
              
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public List<CurrencyRateDto> Rates { get; set; }
    }

    public class CurrencyRateDto 
    {   
        public string CurrencyRateDate { get; set; }
       
        public string EndOfDayRate { get; set; }
      
        public string AverageRate { get; set; }
      
        public string ToCurrencyCode { get; set; }
      
        public string FromCurrencyCode { get; set; }  
    }
}