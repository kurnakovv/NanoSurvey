using AutoMapper;
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
            ISurveyServiceAsync surveyServiceAsync,
            IMapper mapper)
        {
            _surveyServiceAsync = surveyServiceAsync;
            _mapper = mapper;
        }

        private readonly ISurveyServiceAsync _surveyServiceAsync;
        private readonly IMapper _mapper;

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

                var questionAnswersDTO = _mapper.Map<QuestionAnswersDTO>(question);

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
                var result = _mapper.Map<Result>(resultDTO);

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
