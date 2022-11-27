using AutoMapper;
using create_test.Services.Abstract;
using create_test.Services.Models;
using create_tests.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestTimetable.Controllers
{
    /// <summary>
    /// Tests endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService testService;
        private readonly IMapper mapper;

        /// <summary>
        /// Tests controller
        /// </summary>
        public TestsController(ITestService testService, IMapper mapper)
        {
            this.testService = testService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Tests by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTests([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = testService.GetTests(limit, offset);
            return Ok(mapper.Map<PageResponse<TestPreviewResponse>>(pageModel));
        }


        /// <summary>
        /// Update Test
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTest([FromRoute] Guid id, [FromBody] UpdateTestRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = testService.UpdateTest(id, mapper.Map<UpdateTestModel>(model));

                return Ok(mapper.Map<TestResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Test
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTest([FromRoute] Guid id)
        {
            try
            {
                testService.DeleteTest(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Test
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTest([FromRoute] Guid id)
        {
            try
            {
                var testModel = testService.GetTest(id);
                return Ok(mapper.Map<TestResponse>(testModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}