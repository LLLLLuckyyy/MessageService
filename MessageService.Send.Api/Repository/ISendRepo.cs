using MessageService.Common.ExtraModels;
using System.Threading.Tasks;

namespace MessageService.Send.Api.Repository
{
    public interface ISendRepo
    {   
        Task SendMessageAsync(SendModelDto request);
    }
}
