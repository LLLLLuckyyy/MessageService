using System.Collections.Generic;

namespace MessageService.Resources.Api.Models
{
    public class FullMessageInfo
    {
        public int CountOfMessages { get; set; }
        
        public IEnumerable<AssociationInfo> FullInfo { get; set; }
    }
}
