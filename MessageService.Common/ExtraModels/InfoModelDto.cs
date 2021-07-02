using System;
using static MessageService.Common.ExtraModels.Country;

namespace MessageService.Common.ExtraModels
{
    public class InfoModelDto
    {
        public DateTime DateGetSentFrom { get; set; }

        public Countries CountryGetSentFrom { get; set; }

        public Countries CountryGetSentTo { get; set; }

        public decimal PricePerMessage { get; set; }
    }
}
