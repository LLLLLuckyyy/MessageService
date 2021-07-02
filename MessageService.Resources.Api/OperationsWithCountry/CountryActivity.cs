using MessageService.Common.ExtraModels;
using MessageService.Resources.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace MessageService.Resources.Api.OperationsWithCountry
{
    public static class CountryActivity
    {
        public static string GetTheMostActiveCountry(IEnumerable<InfoModel> datas)
        {
            int GermanyCount = 0, AustriaCount = 0, PolandCount = 0, UkraineCount = 0, USACount = 0;

            foreach (var data in datas)
            {
                switch (data.CountryGetSentFrom)
                {
                    case Country.Countries.Germany:
                        GermanyCount += 1;
                        break;
                    case Country.Countries.Austria:
                        AustriaCount += 1;
                        break;
                    case Country.Countries.Poland:
                        PolandCount += 1;
                        break;
                    case Country.Countries.Urkaine:
                        UkraineCount += 1;
                        break;
                    case Country.Countries.USA:
                        USACount += 1;
                        break;
                }
            }
            
            string mostActiveCountry = Comparison(GermanyCount, AustriaCount, PolandCount, UkraineCount, USACount);

            return mostActiveCountry;
        }

        private static string Comparison(int Germany, int Austria, int Poland, int Ukraine, int USA)
        {
            var dict = new Dictionary<string, int>();
            dict.Add(Country.Countries.Germany.ToString(), Germany);
            dict.Add(Country.Countries.Austria.ToString(), Austria);
            dict.Add(Country.Countries.Urkaine.ToString(), Ukraine);
            dict.Add(Country.Countries.Poland.ToString(), Poland);
            dict.Add(Country.Countries.USA.ToString(), USA);
            dict.Add(Country.Countries.NotRegistered.ToString(), 0);

            var maxCount = dict.Values.Max();

            return dict.Where(c => c.Value == maxCount).FirstOrDefault().Key;
        }
    }
}
