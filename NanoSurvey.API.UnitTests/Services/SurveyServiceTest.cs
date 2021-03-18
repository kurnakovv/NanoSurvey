using Moq;
using NanoSurvey.API.Entities;
using NanoSurvey.API.Services.Abstract;
using Xunit;

namespace NanoSurvey.API.UnitTests.Services
{
    public class SurveyServiceTest
    {
        private readonly Question question = new Question() 
        { 
            Title = "Title",
        };

        [Fact]
        public void GetQuestionById_GetQuestionByValidId_Question()
        {
            var surveyService = new Mock<ISurveyService>();

            var result = surveyService.Setup(s 
                => s.GetQuestionById(1))
                    .ReturnsAsync(question);

            Assert.NotNull(result);
            Assert.Equal(question.Title,
                surveyService.Object.GetQuestionById(1).Result.Title);
        }
    }
}
