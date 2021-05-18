using System;
using System.Collections.Generic;

namespace ExtraClasses
{
    [Serializable]
    public static class GetCountries
    {
        public static Dictionary<Country.Countries,decimal> Prices { get; set; }

        public static Dictionary<Country.Countries,string> CountryMobileCodes { get; set; }
        
        public static Dictionary<string, int> CountryCodes { get; set; }
    }
}
