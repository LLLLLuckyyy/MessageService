using MessageService.Common.ExtraModels;
using MessageService.Common.Information;
using System;
using System.Collections.Generic;

namespace MessageService.Resources.Api.ModelsFilling
{
    public static class FillingOfCountryInformation
    {
        public static void GenerateInfo(List<BasicCountriesInfo> countriesInfo)
        {
            foreach (Country.Countries country in Enum.GetValues(typeof(Country.Countries)))
            {
                countriesInfo.Add(new BasicCountriesInfo
                {
                    Country = country.ToString(),
                    MobileCountryCode = Country.CountryMobileCodes.GetValueOrDefault(country),
                    CountryCode = ((int)country),
                    PricePerMessage = Country.Prices.GetValueOrDefault(country)
                });
            }
        }
    }
}
