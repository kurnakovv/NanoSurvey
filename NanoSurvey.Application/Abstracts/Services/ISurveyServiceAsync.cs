using NanoSurvey.Application.Entities;
using System.Threading.Tasks;

namespace NanoSurvey.Application.Abstracts.Services
{
    public interface ISurveyServiceAsync
    {
        Task<Question> GetQuestionByIdAsync(int id);
        Task<int> SaveQuestionResultAsync(Result result);
    }
}
