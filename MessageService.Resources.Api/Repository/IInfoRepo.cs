using MessageService.Common.Information;
using MessageService.Common.Statistics;
using MessageService.Resources.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageService.Resources.Api.Repository
{
    public interface IInfoRepo
    {
        Task<FullMessageInfo> GetFullInfoAsync();
        
        Task<FullMessageInfo> GetFullInfoAsync(int skip, int take);
        
        StatisticsPerAllTime GetStatisticsAsync();
        
        StatisticsPerDay GetStatisticsAsync(DateTime day);
        
        List<BasicCountriesInfo> GetCountriesInfoAsync();
    }
}
