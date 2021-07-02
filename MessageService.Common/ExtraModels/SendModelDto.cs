namespace MessageService.Common.ExtraModels
{
    public class SendModelDto
    {
        public string PhoneNumberFrom { get; set; }

        public string PhoneNumberTo { get; set; }
        
        public string Text { get; set; }
        
        public string AccountSid { get; set; }
        
        public string AuthToken { get; set; }
    }
}
