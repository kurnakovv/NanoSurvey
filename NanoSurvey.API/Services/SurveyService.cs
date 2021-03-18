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
                throw new ObjectNotFoundException($"Question by id: {id} not found");
            }

            return question;
        }

        public async Task<int> SaveQuestionResult(Question question)
        {
            throw new NotImplementedException();
            //var findedQuestion = await _appDbContext.Questions
            //    //.Include(q => q.Answers)
            //    .Include(q => q.Survey.Interview.Result.Answers)
            //    .FirstOrDefaultAsync(q => q.Id == question.Id);

            //findedQuestion.Answers = question.Answers;

            //if (question.Id == 0)
            //{
            //    return -1;
            //}

            //_appDbContext.Results.Add(findedQuestion.Survey.Interview.Result);
            //await _appDbContext.SaveChangesAsync();

            //var nextQuestionId = question.Id + 1;
            //return nextQuestionId;
        }
    }
}
