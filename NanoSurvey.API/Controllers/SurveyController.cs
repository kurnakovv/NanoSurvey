using Microsoft.AspNetCore.Mvc;
using NanoSurvey.API.DTOs;
using NanoSurvey.Application.Abstracts.Services;
using NanoSurvey.Application.Entities;
using NanoSurvey.Application.Exceptions;
using System.Threading.Tasks;

namespace NanoSurvey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        public SurveyController(
            ISurveyServiceAsync surveyServiceAsync)
        {
            _surveyServiceAsync = surveyServiceAsync;
        }

        private readonly ISurveyServiceAsync _surveyServiceAsync;

        /// <summary>
        /// Get question.
        /// </summary>
        /// <param name="id">Question id.</param>
        /// <returns>Question.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            try
            {
                var question = await _surveyServiceAsync.GetQuestionByIdAsync(id);

                var questionAnswersDTO = new QuestionAnswersDTO()
                {
                    Question = question,
                    Answers = question.Answers,
                };

                return Ok(questionAnswersDTO);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Save question result.
        /// </summary>
        /// <param name="resultDTO">Current result.</param>
        /// <returns>Next question id.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Save(ResultDTO resultDTO)
        {
            try
            {
                var result = new Result()
                {
                    QuestionId = resultDTO.QuestionId,
                    AnswerId = resultDTO.AnswerId,
                };

                var nextQuestionId = await _surveyServiceAsync.SaveQuestionResultAsync(result);

                return Ok(nextQuestionId);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
