using Microsoft.EntityFrameworkCore;
using NanoSurvey.Application.Abstracts.Repositories;
using NanoSurvey.Application.Entities;
using NanoSurvey.Infrastructure.DBContexts;
using System.Threading.Tasks;

namespace NanoSurvey.Infrastructure.Data
{
    public class SurveyRepositoryAsync : ISurveyRepositoryAsync
    {
        public SurveyRepositoryAsync(
            AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private readonly AppDbContext _appDbContext;

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            var answer = await _appDbContext.Answers.
                                    FirstOrDefaultAsync(a => a.Id == id);

            return answer;
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            var question = await _appDbContext.Questions
                .Include(q => q.Answers)
                .Include(q => q.Survey)
                    .FirstOrDefaultAsync(q => q.Id == id);

            return question;
        }

        public async Task SaveResultAsync(Result result)
        {
            var interview = new Interview()
            {
                Result = result,
            };

            _appDbContext.Results.Add(result);
            _appDbContext.Interviews.Add(interview);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
