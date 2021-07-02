using MessageService.Resources.Api.Models;
using System;
using System.Collections.Generic;
using static MessageService.Common.ExtraModels.Country;

namespace MessageService.Resources.Api.OperationsWithMessage
{
    public static class MessageCost
    {
        public static decimal GetTotalIncome(IEnumerable<InfoModel> requests)
        {
            decimal totalIncome = 0;
            foreach (var request in requests)
            {
                totalIncome += request.PricePerMessage;
            }
            return totalIncome;
        }

        public static decimal GetMessagePriceUsingCountryName(string country)
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
        public static decimal GetMessagePriceUsingMobileCountryCode(string mobileCountryCode)
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
