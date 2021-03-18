using Microsoft.AspNetCore.Mvc;
using NanoSurvey.API.Entities;
using NanoSurvey.API.Exceptions;
using NanoSurvey.API.Services.Abstract;
using System.Threading.Tasks;

namespace NanoSurvey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        public SurveyController(
            ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        private readonly ISurveyService _surveyService;

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
                var question = await _surveyService.GetQuestionById(id);

                return Ok(question);
            }
            catch(ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Save question result.
        /// </summary>
        /// <param name="question">Current question.</param>
        /// <returns>Next question id.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Save(Question question)
        {
            var nextQuestionId = await _surveyService.SaveQuestionResult(question);

            return nextQuestionId;
        }
    }
}
