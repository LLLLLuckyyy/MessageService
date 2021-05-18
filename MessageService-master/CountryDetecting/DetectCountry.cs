using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using static ExtraClasses.Country;

namespace MessageService.CountryDetecting
{
    public static class DetectCountry
    {
        public static Countries DetectingProcess(string country)
        {
            foreach (var c in CountryMobileCodes)
            {
                if (country.Contains(c.Value))
                {
                    return c.Key;
                }
            }
            return Countries.NotRegistered;
        }
    }
}
