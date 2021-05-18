using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using MessageService.Models;
using Twilio.Rest.Api.V2010.Account;
using MessageService.MessageSending;
using MessageService.CountryDetecting;
using MessageService.Calculus;

namespace MessageService.Data
{
    public class SqlSendServiceRepo : ISendServiceRepo
    {
        private readonly SMSContext context;

        public enum Result
        {
            Failed = 0,
            Success = 1
        }

        public SqlSendServiceRepo(SMSContext context)
        {
            this.context = context;
        }

        public ObjectResult SendSMS()
        {
            return new ObjectResult(0);
        }

        public async Task<string> SendSMS(SendModel model)
        {
            MessageResource resource = null;
            try
            {
                SendMessage.Send(resource, model);
            }
            catch (Exception)
            {
                return Result.Failed.ToString();
            }

            if (resource != null && string.IsNullOrWhiteSpace(resource.Body) == false && resource.DateCreated != null)
            {
                model.GetSentModel.DateGetSentFrom = resource.DateCreated.Value;
                model.GetSentModel.CountryGetSentFrom = DetectCountry.DetectingProcess(model.NumberFrom);
                model.GetSentModel.CountryGetSentTo = DetectCountry.DetectingProcess(model.NumberTo);
                model.GetSentModel.PricePerMessage = MessageCosts.MessagePriceUsingCountryName(model.GetSentModel.CountryGetSentFrom.ToString());

                if (context.TotalCounts.FirstOrDefault() == null)
                {
                    TotalCount messagesPerAllTime = new TotalCount();
                    messagesPerAllTime.Count = 1;
                    context.TotalCounts.Add(messagesPerAllTime);
                }
                else
                {
                    var messagesPerAllTime = context.TotalCounts.FirstOrDefault();
                    messagesPerAllTime.Count += 1;
                    context.Entry(messagesPerAllTime).State = EntityState.Modified;
                }

                await context.SendModels.AddAsync(model);
                await context.GetSentModels.AddAsync(model.GetSentModel);
                await context.SaveChangesAsync();
                return Result.Success.ToString();
            }
            return Result.Failed.ToString();
        }
    }
}
