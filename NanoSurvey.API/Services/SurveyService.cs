using Microsoft.EntityFrameworkCore;
using NanoSurvey.API.DBContexts;
using NanoSurvey.API.Entities;
using NanoSurvey.API.Exceptions;
using NanoSurvey.API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NanoSurvey.API.Services
{
    public class SurveyService : ISurveyService
    {
        public SurveyService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private readonly AppDbContext _appDbContext;

        public async Task<Question> GetQuestionById(int id)
        {
            var question = await _appDbContext.Questions
                .Include(q => q.Answers)
                .Include(q => q.Survey)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Question by id: {id} not found.");
            }

            return question;
        }

        public async Task<int> SaveQuestionResult(Result result)
        {
            await GetQuestionById(result.QuestionId);
            await GetAnswerById(result.AnswerId);

            var interview = new Interview()
            {
                Result = result,
            };

            _appDbContext.Results.Add(result);
            _appDbContext.Interviews.Add(interview);

            await _appDbContext.SaveChangesAsync();

            int nextQuestionId = await TryGetNextQuestionId(result.QuestionId);

            return nextQuestionId;
        }

        private async Task<Answer> GetAnswerById(int answerId)
        {
            var answer = await _appDbContext.Answers.FirstOrDefaultAsync(a => a.Id == answerId);

            if(answer == null)
            {
                throw new ObjectNotFoundException($"Answer by id {answerId} not found.");
            }

            return answer;
        }

        private async Task<int> TryGetNextQuestionId(int questionId)
        {
            var nextQuestionId = questionId + 1;

            var question = await _appDbContext.Questions.FirstOrDefaultAsync(q => q.Id == nextQuestionId);

            if(question == null)
            {
                return 0;
            }

            return nextQuestionId;
        }
    }
}
