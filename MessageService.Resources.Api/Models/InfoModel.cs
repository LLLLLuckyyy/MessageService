using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MessageService.Common.ExtraModels.Country;

namespace MessageService.Resources.Api.Models
{
    public class InfoModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateGetSentFrom { get; set; }
        
        public Countries CountryGetSentFrom { get; set; }
        
        public Countries CountryGetSentTo { get; set; }
        
        public decimal PricePerMessage { get; set; }

        [ForeignKey("SendModel")]
        public int SendModelId { get; set; }
    }
}
