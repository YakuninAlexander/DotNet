using AutoMapper;
using create_test.Services.Abstract;
using create_test.Services.Models;
using create_tests.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace create_tests.Controllers
{
    /// <summary>
    /// Questions endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;

        /// <summary>
        /// Questions controller
        /// </summary>
        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get questions by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetQuestions([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = questionService.GetQuestions(limit, offset);
            return Ok(mapper.Map<PageResponse<QuestionPreviewResponse>>(pageModel));
        }


        /// <summary>
        /// Update question
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateQuestion([FromRoute] Guid id, [FromBody] UpdateQuestionRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = questionService.UpdateQuestion(id, mapper.Map<UpdateQuestionModel>(model));

                return Ok(mapper.Map<QuestionResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete question
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteQuestion([FromRoute] Guid id)
        {
            try
            {
                questionService.DeleteQuestion(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get question
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuestion([FromRoute] Guid id)
        {
            try
            {
                var questionModel = questionService.GetQuestion(id);
                return Ok(mapper.Map<QuestionResponse>(questionModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}