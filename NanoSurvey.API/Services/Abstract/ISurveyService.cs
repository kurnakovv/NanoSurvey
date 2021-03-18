using NanoSurvey.API.Entities;
using System.Threading.Tasks;

namespace NanoSurvey.API.Services.Abstract
{
    public interface ISurveyService
    {
        Task<Question> GetQuestionById(int id);
        Task<int> SaveQuestionResult(Question question);
    }
}
