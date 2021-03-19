using Moq;
using NanoSurvey.Application.Abstracts.Services;
using NanoSurvey.Application.Entities;
using Xunit;

namespace NanoSurvey.Application.UnitTests.Services
{
    public class SurveyServiceAsyncTest
    {
        private readonly Question _question = new Question()
        {
            Title = "Title",
        };

        private readonly Result _result = new Result()
        {
            QuestionId = 1,
            AnswerId = 1,
        };

        [Fact]
        public void GetQuestionByIdAsync_GetQuestionByValidId_Question()
        {
            var surveyService = new Mock<ISurveyServiceAsync>();

            var result = surveyService.Setup(s => s.GetQuestionByIdAsync(1))
                                        .ReturnsAsync(_question);

            Assert.NotNull(result);
            Assert.Equal(_question.Title,
                surveyService.Object.GetQuestionByIdAsync(1).Result.Title);
        }

        [Fact]
        public void SaveQuestionResultAsync_SaveValidQuestionResult_NextQuestionId()
        {
            var surveyService = new Mock<ISurveyServiceAsync>();
            var nextQuestionId = _result.QuestionId + 1;

            var result = surveyService.Setup(s => s.SaveQuestionResultAsync(_result))
                                        .ReturnsAsync(nextQuestionId);

            Assert.NotNull(result);
            Assert.Equal(nextQuestionId, surveyService.Object.SaveQuestionResultAsync(_result).Result);
        }
    }
}
