using NanoSurvey.Application.Abstracts.Repositories;
using NanoSurvey.Application.Abstracts.Services;
using NanoSurvey.Application.Entities;
using NanoSurvey.Application.Exceptions;
using System.Threading.Tasks;

namespace NanoSurvey.Application.Services
{
    public class SurveyServiceAsync : ISurveyServiceAsync
    {
        public SurveyServiceAsync(ISurveyRepositoryAsync surveyRepositoryAsync)
        {
            _surveyRepositoryAsync = surveyRepositoryAsync;
        }

        private readonly ISurveyRepositoryAsync _surveyRepositoryAsync;

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            var question = await _surveyRepositoryAsync.GetQuestionByIdAsync(id);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Question by id: {id} not found.");
            }

            return question;
        }

        public async Task<int> SaveQuestionResultAsync(Result result)
        {
            await GetQuestionByIdAsync(result.QuestionId);
            await GetAnswerByIdAsync(result.AnswerId);

            await _surveyRepositoryAsync.SaveResultAsync(result);

            int nextQuestionId = await TryGetNextQuestionIdAsync(result.QuestionId);

            return nextQuestionId;
        }

        private async Task<Answer> GetAnswerByIdAsync(int answerId)
        {
            var answer = await _surveyRepositoryAsync.GetAnswerByIdAsync(answerId);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Answer by id {answerId} not found.");
            }

            return answer;
        }

        private async Task<int> TryGetNextQuestionIdAsync(int questionId)
        {
            var nextQuestionId = questionId + 1;
            var endOfQuestions = 0;

            var question = await _surveyRepositoryAsync.GetQuestionByIdAsync(nextQuestionId);

            if (question == null)
            {
                return endOfQuestions;
            }

            return nextQuestionId;
        }
    }
}
