using System.ComponentModel.DataAnnotations;

namespace MessageService.Models
{
    public class TotalCount
    {
        [Key]
        public int Id { get; set; }
        
        public int Count { get; set; }
    }
}
