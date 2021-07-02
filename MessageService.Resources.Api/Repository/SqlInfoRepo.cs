using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Resources.Api.Models;
using MessageService.Resources.Api.ModelsFilling;
using MessageService.Resources.Api.OperationsWithMessage;
using MessageService.Resources.Api.OperationsWithCountry;
using MessageService.Common.Information;
using MessageService.Common.Statistics;
using MessageService.Info.Api.ModelToDtoConverting;

namespace MessageService.Resources.Api.Repository
{
    public class SqlInfoRepo : IInfoRepo
    {
        private readonly MessageContext context;

        public SqlInfoRepo(MessageContext context)
        {
            this.context = context;
        }

        public List<BasicCountriesInfo> GetCountriesInfoAsync()
        {
            List<BasicCountriesInfo> countriesInfo = new List<BasicCountriesInfo>();

            FillingOfCountryInformation.GenerateInfo(countriesInfo);

            return countriesInfo;
        }

        public async Task<FullMessageInfo> GetFullInfoAsync()
        {
            var messages = await context.SendModels.ToListAsync();

            var fullInfo = messages.Join(context.InfoModels, m => m.Id, i => i.SendModelId,
                (m, i) => new AssociationInfo 
                { 
                    Message = ModelConverting.GetSendModelDto(m), 
                    MessageInfo = ModelConverting.GetInfoModelDto(i) 
                });

            return new FullMessageInfo
            {
                CountOfMessages = messages.Count,
                FullInfo = fullInfo
            };
        }

        public async Task<FullMessageInfo> GetFullInfoAsync(int skip, int take)
        {
            var messages = await context.SendModels.Skip(skip).Take(take).ToListAsync();

            var fullInfo = messages.Join(context.InfoModels, m => m.Id, i => i.SendModelId,
                (m, i) => new AssociationInfo 
                { 
                    Message = ModelConverting.GetSendModelDto(m),
                    MessageInfo = ModelConverting.GetInfoModelDto(i) 
                });

            return new FullMessageInfo
            {
                CountOfMessages = messages.Count,
                FullInfo = fullInfo
            };
        }

        public StatisticsPerAllTime GetStatisticsAsync()
        {
            var selectedData = context.InfoModels.AsEnumerable();
            int countOfMessages = selectedData.Count();
            decimal totalIncome = MessageCost.GetTotalIncome(selectedData);
            string mostActiveCountry = CountryActivity.GetTheMostActiveCountry(selectedData);
            decimal PriceAtTheMostActiveCountry = MessageCost.GetMessagePriceUsingCountryName(mostActiveCountry);
            
            return new StatisticsPerAllTime
            {
                CountOfCallsPerAllTime = countOfMessages,
                TotalIncomePerAllTime = totalIncome,
                TheMostActiveCountry = mostActiveCountry,
                PricePerMessageAtTheMostActiveCountry = PriceAtTheMostActiveCountry
            };
        }

        public StatisticsPerDay GetStatisticsAsync(DateTime day)
        {
            var selectedData = context.InfoModels.AsEnumerable().Where(d =>
            d.DateGetSentFrom.ToString("yyyyMMdd").Contains(day.ToString("yyyyMMdd")));

            int countOfMessages = selectedData.Count();
            decimal totalIncome = MessageCost.GetTotalIncome(selectedData);
            string mostActiveCountry = CountryActivity.GetTheMostActiveCountry(selectedData);
            decimal priceAtTheMostActiveCountry = MessageCost.GetMessagePriceUsingCountryName(mostActiveCountry);

            return new StatisticsPerDay
            {
                Date = day,
                TotalIncomePerDay = totalIncome,
                CountOfCallsPerDay = countOfMessages,
                TheMostActiveCountry = mostActiveCountry,
                PricePerMessageAtTheMostActiveCountry = priceAtTheMostActiveCountry
            };
        }
    }
}
