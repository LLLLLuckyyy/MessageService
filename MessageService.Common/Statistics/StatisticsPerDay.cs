using System;

namespace MessageService.Common.Statistics
{
    public class StatisticsPerDay
    {
        public DateTime Date { get; set; }
        
        public decimal TotalIncomePerDay { get; set; }
        
        public int CountOfCallsPerDay { get; set; }
        
        public string TheMostActiveCountry { get; set; }
        
        public decimal PricePerMessageAtTheMostActiveCountry { get; set; }
    }
}
