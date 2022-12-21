using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Statistics;
using WebProject.Services.Statistics.Models;

namespace WebProject.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : Controller
    {
        private readonly IStatisticService statisticService;

        public StatisticsApiController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }

        [HttpGet]
        public StatisticsServiceModel GetStatistics()
        {
            return statisticService.Total();
        }
    }
}
