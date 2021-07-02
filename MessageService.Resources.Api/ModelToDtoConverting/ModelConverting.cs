using MessageService.Common.ExtraModels;
using MessageService.Resources.Api.Models;

namespace MessageService.Info.Api.ModelToDtoConverting
{
    public static class ModelConverting
    {
        public static SendModelDto GetSendModelDto(SendModel model)
        {
            return new SendModelDto
            {
                PhoneNumberTo = model.PhoneNumberTo,
                PhoneNumberFrom = model.PhoneNumberFrom,
                Text = model.Text,
                AccountSid = model.AccountSid,
                AuthToken = model.AuthToken
            };
        }

        public static InfoModelDto GetInfoModelDto(InfoModel model)
        {
            return new InfoModelDto
            {
                DateGetSentFrom = model.DateGetSentFrom,
                CountryGetSentFrom = model.CountryGetSentFrom,
                CountryGetSentTo = model.CountryGetSentTo,
                PricePerMessage = model.PricePerMessage
            };
        }
    }
}
