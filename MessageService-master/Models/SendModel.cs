using System.ComponentModel.DataAnnotations;
using MessageService.ValidationAttributes;

namespace MessageService.Models
{
    public class SendModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [NumberContains]
        public string NumberFrom { get; set; }
        
        [Required]
        [NumberContains]
        public string NumberTo { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public string AccountSid { get; set; }
        
        [Required]
        public string AuthToken { get; set; }

        public GetSentModel GetSentModel { get; set; }
    }
}
