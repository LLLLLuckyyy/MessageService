using Microsoft.AspNetCore.Mvc;
using MessageService.Models;
using Microsoft.Extensions.Logging;
using MessageService.Data;
using System.Threading.Tasks;

namespace MessageService.Controllers
{
    [Route("message")]
    [ApiController]
    [FormatFilter]
    public class SendController : ControllerBase
    {
        private readonly ISendServiceRepo _repository;
        private readonly ILogger<SendController> _logger;


        public SendController(ILogger<SendController> logger, ISendServiceRepo repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("test.{format}")]
        public ObjectResult SendSMS() 
        {
            return new ObjectResult(0);
        }

        [HttpPost("send.{format}")]
        public async Task<string> SendSMS(SendModel model)
        {
            if (ModelState.IsValid)
            {
                return await _repository.SendSMS(model);
            }
            return SqlSendServiceRepo.Result.Failed.ToString();
        }

    }
}