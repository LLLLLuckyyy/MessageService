using System.Threading.Tasks;
using MessageService.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageService.MessageSending
{
    public static class SendMessage
    {
        public static void Send(MessageResource resource, SendModel model)
        {
            TwilioClient.Init(model.AccountSid, model.AuthToken);
            resource = MessageResource.Create(
                body: model.Text,
                from: new PhoneNumber(model.NumberFrom),
                to: new PhoneNumber(model.NumberTo)
            );
        }
    }
}
