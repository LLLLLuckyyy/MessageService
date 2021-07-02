using MessageService.Common.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageService.Resources.Api.Models
{
    public class SendModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [NumberContains]
        public string PhoneNumberFrom { get; set; }
        
        [Required]
        [NumberContains]
        public string PhoneNumberTo { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public string AccountSid { get; set; }
        
        [Required]
        public string AuthToken { get; set; }


        public InfoModel InfoModel { get; set; }
    }
}
