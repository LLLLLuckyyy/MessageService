namespace MessageService.Common.Statistics
{
    public class StatisticsPerAllTime
    {
        public int CountOfCallsPerAllTime { get; set; }

        public decimal TotalIncomePerAllTime { get; set; }
        
        public string TheMostActiveCountry { get; set; }
        
        public decimal PricePerMessageAtTheMostActiveCountry { get; set; }
    }
}
