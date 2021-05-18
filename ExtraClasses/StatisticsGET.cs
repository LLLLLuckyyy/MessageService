using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses
{
    public class StatisticsGET
    {
        public int CountOfCallsPerAllTime { get; set; }

        public decimal TotalIncomePerAllTime { get; set; }
        
        public string MobileCountryCodeOfTheMostActiveCountry { get; set; }
        
        public decimal PricePerMessageAtTheMostActiveCountry { get; set; }
    }
}
