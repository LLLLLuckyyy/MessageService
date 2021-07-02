using MessageService.Common.ExtraModels;

namespace MessageService.Resources.Api.Models
{
    public class AssociationInfo
    {
        public SendModelDto Message { get; set; }
        public InfoModelDto MessageInfo { get; set; }
    }
}
