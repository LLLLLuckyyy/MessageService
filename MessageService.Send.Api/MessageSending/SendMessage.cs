using MessageService.Common.ExtraModels;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageService.Send.Api.OperationsWithMessage
{
    public static class SendMessage
    {
        public static MessageResource Send(SendModelDto request)
        {
            TwilioClient.Init(request.AccountSid, request.AuthToken);
            MessageResource resource = MessageResource.Create(
                body: request.Text,
                from: new PhoneNumber(request.PhoneNumberFrom),
                to: new PhoneNumber(request.PhoneNumberTo)
            );
            return resource;
        }
    }
}
