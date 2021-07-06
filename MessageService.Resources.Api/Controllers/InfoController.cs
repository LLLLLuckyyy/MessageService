using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessageService.Resources.Api.Repository;
using MessageService.Common.Information;
using MessageService.Common.Statistics;
using MessageService.Resources.Api.Models;

namespace MessageService.Resources.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepo _repository;

        public InfoController(IInfoRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<FullMessageInfo> GetInfo()
        {
            try
            {
                var info = await _repository.GetFullInfoAsync();
                return info;
            }
            catch (Exception)
            {
                return new FullMessageInfo();
            }
        }

        [HttpPost("[action]")]
        public async Task<FullMessageInfo> GetInfo(int skip, int take)
        {
            if (skip >= 0 && take > 0)
            {
                try
                {
                    return await _repository.GetFullInfoAsync(skip, take);
                }
                catch (Exception)
                {
                    return new FullMessageInfo();
                }
            }
            else
            {
                return new FullMessageInfo();
            }
        }

        [HttpGet("[action]")]
        public StatisticsPerAllTime GetStatistics()
        {
            try
            {
                var statistics = _repository.GetStatisticsAsync();
                return statistics;
            }
            catch (Exception)
            {
                return new StatisticsPerAllTime();
            }
        }

        [HttpPost("[action]")]
        public StatisticsPerDay GetStatistics(DateTime day)
        {
            try
            {
                var statistics = _repository.GetStatisticsAsync(day);
                return statistics;
            }
            catch (Exception)
            {
                return new StatisticsPerDay();
            }
        }

        [HttpGet("[action]")]
        public List<BasicCountriesInfo> GetCountries()
        {
            try
            {
                var info = _repository.GetCountriesInfoAsync();
                return info;
            }
            catch (Exception)
            {
                return new List<BasicCountriesInfo>();
            }
        }

    }
}
