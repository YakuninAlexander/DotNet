using AutoMapper;
using create_test.Services.Abstract;
using create_test.Services.Models;
using create_tests.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace create_tests.Controllers
{
    /// <summary>
    /// Statistics endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService statisticService;
        private readonly IMapper mapper;

        /// <summary>
        /// Statistics controller
        /// </summary>
        public StatisticsController(IStatisticService statisticService, IMapper mapper)
        {
            this.statisticService = statisticService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get statistics by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetStatistics([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = statisticService.GetStatistics(limit, offset);
            return Ok(mapper.Map<PageResponse<StatisticPreviewResponse>>(pageModel));
        }


        /// <summary>
        /// Update statistic
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStatistic([FromRoute] Guid id, [FromBody] UpdateStatisticRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = statisticService.UpdateStatistic(id, mapper.Map<UpdateStatisticModel>(model));

                return Ok(mapper.Map<StatisticResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Create Statistic
        /// </summary>
        [HttpPost]
        public IActionResult CreateStatistic([FromBody] CreateStatisticRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = statisticService.CreateStatistic(mapper.Map<CreateStatisticModel>(model));

                return Ok(mapper.Map<StatisticResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete statistic
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStatistic([FromRoute] Guid id)
        {
            try
            {
                statisticService.DeleteStatistic(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get statistic
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStatistic([FromRoute] Guid id)
        {
            try
            {
                var statisticModel = statisticService.GetStatistic(id);
                return Ok(mapper.Map<StatisticResponse>(statisticModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}