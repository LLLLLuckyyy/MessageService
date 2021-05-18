using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ExtraClasses.Country;

namespace MessageService.Models
{
    public class GetSentModel
    {
        [Key]
        [ForeignKey("SendModel")]
        public int Id { get; set; }

        public DateTime DateGetSentFrom { get; set; }
        
        public Countries CountryGetSentFrom { get; set; }
        
        public Countries CountryGetSentTo { get; set; }
        
        public decimal PricePerMessage { get; set; }
    }
}
