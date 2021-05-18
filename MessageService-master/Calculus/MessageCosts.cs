using System;
using static ExtraClasses.Country;

namespace MessageService.Calculus
{
    public static class MessageCosts
    {
        public static decimal MessagePriceUsingCountryName(string country)
        {
            foreach (Countries c in Enum.GetValues(typeof(Countries)))
            {
                if (c.ToString().Contains(country))
                {
                    return Prices.GetValueOrDefault(c);
                }
            }
            return 0.0M;
        }
        public static decimal MessagePriceUsingMobileCountryCode(string mobileCountryCode)
        {
            foreach(Countries country in Enum.GetValues(typeof(Countries)))
            {
                if(mobileCountryCode == CountryMobileCodes.GetValueOrDefault(country))
                {
                    return Prices.GetValueOrDefault(country);
                }
            }
            return 0.0M;
        }
    }
}
