using Microsoft.EntityFrameworkCore;

namespace MessageService.Resources.Api.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) 
        { 
            //Database.EnsureCreated(); 
        }
        
        public DbSet<SendModel> SendModels { get; set; }
        
        public DbSet<InfoModel> InfoModels { get; set; }
    }
}
