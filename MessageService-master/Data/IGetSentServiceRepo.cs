using ExtraClasses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MessageService.Models;

namespace MessageService.Data
{
    public interface IGetSentServiceRepo
    {
        Task<IEnumerable<LookThroughGET>> LookThroughGET();
        
        Task<LookThroughPOST> LookThroughPOST(int skip, int take);
        
        StatisticsGET StatisticsGET();
        
        StatisticsPOST StatisticsPOST(DateTime day);
        
        List<XElement> GetCountries();
    }
}
