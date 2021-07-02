using System.Collections.Generic;

namespace MessageService.Common.ExtraModels
{
    public static class Country
    {
        public enum Countries
        {
            Germany = 49,
            Austria = 43,
            Poland = 48,
            Urkaine = 77,
            USA = 54,
            NotRegistered = 0
        }
        
        public static Dictionary<Countries, string> CountryMobileCodes = new Dictionary<Countries, string>
        {
            { Countries.Germany, "+262" },
            { Countries.Austria, "+232" },
            { Countries.Poland, "+260" },
            { Countries.Urkaine, "+380" },
            { Countries.USA, "+1" },
            { Countries.NotRegistered, "error" }
        };
        
        public static Dictionary<Countries, decimal> Prices = new Dictionary<Countries, decimal>
        {
            { Countries.Germany, 0.055M },
            { Countries.Austria, 0.053M },
            { Countries.Poland, 0.032M },
            { Countries.Urkaine, 0.03M},
            { Countries.USA, 0.034M },
            { Countries.NotRegistered, 0.0M }
        };
    }
}
