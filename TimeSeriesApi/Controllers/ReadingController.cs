using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSeriesApi.Interface;

namespace TimeSeriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingRepository readingRepository;

        public ReadingController(IReadingRepository readingRepository)
        {
            this.readingRepository = readingRepository;
        }

        [HttpGet]
        [Route("GetParamList")]
        public async Task<IActionResult> GetParam()
        {
            return Ok(await readingRepository.GetParam());
        }

        [HttpGet]
        [Route("GetTimeSeriesDataList")]
        public async Task<IActionResult> TimeSeriesData(int buildingId, int objectId, int dataFieldId, DateTime from, DateTime to)
        {
            return Ok(await readingRepository.TimeSeriesData(buildingId, objectId, dataFieldId, from, to));
        }
    }
}
