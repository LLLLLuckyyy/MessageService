using Microsoft.EntityFrameworkCore;
using MessageService.Models;

namespace MessageService.Data
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options) : base(options) { Database.EnsureCreated(); }
        
        public SMSContext() { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseSqlServer("Server=LuckyMikhail;Database=SMSDB;Trusted_Connection=True;"); }

        
        public DbSet<SendModel> SendModels { get; set; }
        
        public DbSet<GetSentModel> GetSentModels { get; set; }
        
        public DbSet<TotalCount> TotalCounts { get; set; }
    }
}
