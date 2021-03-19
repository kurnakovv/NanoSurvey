using NanoSurvey.Application.Entities;
using System.Threading.Tasks;

namespace NanoSurvey.Application.Abstracts.Repositories
{
    public interface ISurveyRepositoryAsync
    {
        Task<Question> GetQuestionByIdAsync(int id);
        Task<Answer> GetAnswerByIdAsync(int id);
        Task SaveResultAsync(Result result);
    }
}
