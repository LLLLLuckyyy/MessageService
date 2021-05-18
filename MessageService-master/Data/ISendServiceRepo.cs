using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MessageService.Models;

namespace MessageService.Data
{
    public interface ISendServiceRepo
    {
        ObjectResult SendSMS();
        
        Task<string> SendSMS(SendModel service);
    }
}
