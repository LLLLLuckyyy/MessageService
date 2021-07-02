using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using MessageService.Send.Api.Repository;
using MessageService.Common.ExtraModels;
using MessageService.Common.Results;

namespace MessageService.Send.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private readonly ISendRepo _repository;

        public SendController(ISendRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("[action]")]
        public async Task<string> Send(SendModelDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.SendMessageAsync(model);
                    return FinalResult.Result.Success.ToString();
                }
                catch (Exception)
                {
                    return FinalResult.Result.Failed.ToString();
                }
            }
            else
            {
                return FinalResult.Result.Failed.ToString();
            }
        }

    }
}