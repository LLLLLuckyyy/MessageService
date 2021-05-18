using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using MessageService.Models;
using MessageService.Calculus;
using ExtraClasses;

namespace MessageService.Data
{
    public class SqlGetSentServiceRepo : IGetSentServiceRepo
    {
        private readonly SMSContext context;

        public SqlGetSentServiceRepo(SMSContext context)
        {
            this.context = context;
        }

        public List<XElement> GetCountries()
        {
            Dictionary<string, int> countryCodes = new Dictionary<string, int>();
            var values = Enum.GetValues(typeof(Country.Countries));
            foreach (int value in values)
            {
                countryCodes.Add(Enum.GetName(typeof(Country.Countries), value), value);
            }
            var cc = new XElement("CountrieCodes", countryCodes.Select(s => new XElement(s.Key, s.Value)));
            var mcc = new XElement("MobileCountryCodes", Country.CountryMobileCodes.Select(s => new XElement(s.Key.ToString(), s.Value)));
            var p = new XElement("Prices", Country.Prices.Select(s => new XElement(s.Key.ToString(), s.Value)));
            return new List<XElement> { cc, mcc, p }.ToList();
        }

        public async Task<IEnumerable<LookThroughGET>> LookThroughGET()
        {
            return await context.SendModels
                .Select(s => new LookThroughGET
                {
                    Id = s.Id,
                    To = s.NumberTo,
                    From = s.NumberFrom,
                    Text = s.Text,
                    AccountSid = s.AccountSid,
                    AuthToken = s.AuthToken
                }).ToListAsync();
        }

        public async Task<LookThroughPOST> LookThroughPOST(int skip, int take)
        {
            if (skip >= 0 && take > 0)
            {
                int countOfMessages = await context.TotalCounts.FirstOrDefaultAsync() == null ? 0 : context.TotalCounts.FirstOrDefault().Count;
                var messages = context.SendModels.Skip(skip).Take(take);

                return new LookThroughPOST
                {
                    CountOfMessages = countOfMessages,
                    Messages = await messages
                    .Select(s => new LookThroughGET
                    {
                        Id = s.Id,
                        To = s.NumberTo,
                        From = s.NumberFrom,
                        Text = s.Text,
                        AccountSid = s.AccountSid,
                        AuthToken = s.AuthToken
                    }).ToListAsync()
                };
            }
            return new LookThroughPOST
            {
                CountOfMessages = 0,
                Messages = null
            };
        }

        public StatisticsGET StatisticsGET()
        {
            var SelectedData = context.GetSentModels.AsEnumerable();
            if (SelectedData == null || SelectedData.Count() == 0)
                return new StatisticsGET()
                {
                    CountOfCallsPerAllTime = 0,
                    MobileCountryCodeOfTheMostActiveCountry = "absent",
                    PricePerMessageAtTheMostActiveCountry = 0.0M,
                    TotalIncomePerAllTime = 0.0M
                };
            int countOfMessages = SelectedData.Count();
            decimal totalIncome;
            string mostPopularCountry;
            TheMostActiveCountry.GetTheMostPopular(SelectedData, out totalIncome, out mostPopularCountry);
            decimal PriceAtTheMostActiveCountry = MessageCosts.MessagePriceUsingCountryName(mostPopularCountry);
            return new StatisticsGET
            {
                CountOfCallsPerAllTime = countOfMessages,
                TotalIncomePerAllTime = totalIncome,
                MobileCountryCodeOfTheMostActiveCountry = mostPopularCountry,
                PricePerMessageAtTheMostActiveCountry = PriceAtTheMostActiveCountry
            };
        }

        public StatisticsPOST StatisticsPOST(DateTime day)
        {
            var SelectedData = context.GetSentModels.AsEnumerable().Where(d =>
            d.DateGetSentFrom.ToString("yyyyMMdd").Contains(day.ToString("yyyyMMdd")));
            if (SelectedData == null || SelectedData.Count() == 0)
                return new StatisticsPOST()
                {
                    CountOfCallsPerDay = 0,
                    Date = default,
                    MobileCountryCodeOfTheMostActiveCountry = "absent",
                    PricePerMessageAtTheMostActiveCountry = 0,
                    TotalIncomePerDay = 0.0M
                };
            int countOfMessages = SelectedData.Count();
            decimal totalIncome;
            string mostPopularCountry;
            TheMostActiveCountry.GetTheMostPopular(SelectedData, out totalIncome, out mostPopularCountry);
            decimal PriceAtTheMostActiveCountry = MessageCosts.MessagePriceUsingCountryName(mostPopularCountry);

            return new StatisticsPOST
            {
                Date = day,
                TotalIncomePerDay = totalIncome,
                CountOfCallsPerDay = countOfMessages,
                MobileCountryCodeOfTheMostActiveCountry = mostPopularCountry,
                PricePerMessageAtTheMostActiveCountry = PriceAtTheMostActiveCountry
            };
        }
    }
}
