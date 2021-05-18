using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExtraClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MessageService.Data;
using MessageService.Models;


namespace MessageService.Controllers
{
    [Route("message")]
    [ApiController]
    [FormatFilter]
    public class GetSentController : ControllerBase
    {
        private readonly IGetSentServiceRepo _repository;
        private readonly ILogger<GetSentController> _logger;


        [ActivatorUtilitiesConstructor]
        public GetSentController(ILogger<GetSentController> logger, IGetSentServiceRepo repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("sentGET.{format}")]
        public async Task<IEnumerable<LookThroughGET>> LookThrough()
        {
            return await _repository.LookThroughGET();
        }


        [HttpPost("sentPOST.{format}")]
        public async Task<LookThroughPOST> LookThrough(int skip, int take)
        {
            return await _repository.LookThroughPOST(skip, take);
        }

        [HttpGet("StatisticsGET.{format}")]
        public StatisticsGET Statistics()
        {
            return _repository.StatisticsGET();
        }

        [HttpPost("StatisticsPOST.{format}")]
        public StatisticsPOST Statistics(DateTime day)
        {
            return _repository.StatisticsPOST(day);
        }

        [HttpGet("GetCountries.{format}")]
        public List<XElement> GetCountries()
        {
            return _repository.GetCountries();
        }

    }
}