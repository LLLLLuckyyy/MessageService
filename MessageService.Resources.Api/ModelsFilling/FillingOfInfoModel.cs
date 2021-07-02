using MessageService.Resources.Api.Models;
using MessageService.Resources.Api.OperationsWithCountry;
using MessageService.Resources.Api.OperationsWithMessage;
using System.Linq;
using Twilio.Rest.Api.V2010.Account;
using static MessageService.Common.ExtraModels.Country;

namespace MessageService.Resources.Api.ModelsFilling
{
    public static class FillingOfInfoModel
    {
        public static InfoModel GenerateInfo(SendModel processedRequest, MessageResource resource, MessageContext context)
        {
            int savedRequestId = context.SendModels.ToList().Last().Id;
            Countries countryGetSentFrom = DetectCountry.DetectingByPhoneNumber(processedRequest.PhoneNumberFrom);
            Countries countryGetSentTo = DetectCountry.DetectingByPhoneNumber(processedRequest.PhoneNumberTo);

            return new InfoModel
            {
                SendModelId = savedRequestId,
                DateGetSentFrom = resource.DateCreated.Value,
                CountryGetSentFrom = countryGetSentFrom,
                CountryGetSentTo = countryGetSentTo,
                PricePerMessage = MessageCost.GetMessagePriceUsingCountryName(countryGetSentFrom.ToString())
            };
        }
    }
}
