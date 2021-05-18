using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses
{
    public class StatisticsPOST
    {
        public DateTime Date { get; set; }
        
        public decimal TotalIncomePerDay { get; set; }
        
        public int CountOfCallsPerDay { get; set; }
        
        public string MobileCountryCodeOfTheMostActiveCountry { get; set; }
        
        public decimal PricePerMessageAtTheMostActiveCountry { get; set; }
    }
}
