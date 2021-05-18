using ExtraClasses;
using System.Collections.Generic;
using MessageService.Models;

namespace MessageService.Calculus
{
    public static class TheMostActiveCountry
    {
        public static void GetTheMostPopular(IEnumerable<GetSentModel> datas, out decimal totalIncome, out string mostPopularCountry)
        {
            totalIncome = 0.0M;
            int totalGermanyCount = 0, totalAustriaCount = 0, totalPolandCount = 0, totalUkraineCount = 0, totalUSACount = 0;

            foreach (var data in datas)
            {
                totalIncome += data.PricePerMessage;

                switch (data.CountryGetSentFrom)
                {
                    case Country.Countries.Germany:
                        totalGermanyCount += 1;
                        break;
                    case Country.Countries.Austria:
                        totalAustriaCount += 1;
                        break;
                    case Country.Countries.Poland:
                        totalPolandCount += 1;
                        break;
                    case Country.Countries.Urkaine:
                        totalUkraineCount += 1;
                        break;
                    case Country.Countries.USA:
                        totalUSACount += 1;
                        break;
                }
            }
            
            mostPopularCountry = FinalComparison(totalGermanyCount, totalAustriaCount, totalPolandCount, totalUkraineCount, totalUSACount);
        }

        private static string FinalComparison(int Germany, int Austria, int Poland, int Ukraine, int USA)
        {
            if (Austria < Germany && Poland < Germany)
                return Country.CountryMobileCodes.GetValueOrDefault(Country.Countries.Germany);
            else if (Germany < Austria && Poland < Austria)
                return Country.CountryMobileCodes.GetValueOrDefault(Country.Countries.Austria);
            else if (Germany < Ukraine && Poland < Ukraine)
                return Country.CountryMobileCodes.GetValueOrDefault(Country.Countries.Urkaine);
            else if (Germany < USA && Poland < USA)
                return Country.CountryMobileCodes.GetValueOrDefault(Country.Countries.USA);

            return Country.CountryMobileCodes.GetValueOrDefault(Country.Countries.Poland);
        }

    }
}
