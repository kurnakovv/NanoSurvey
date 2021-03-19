using NanoSurvey.Application.Entities;
using System.Collections.Generic;

namespace NanoSurvey.API.DTOs
{
    public class QuestionAnswersDTO
    {
        public Question Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
