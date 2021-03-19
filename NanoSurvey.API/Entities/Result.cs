using System.Collections.Generic;

namespace NanoSurvey.API.Entities
{
    public class Result
    {
        public Result()
        {
            Interviews = new List<Interview>();
        }

        public int Id { get; set; }
        public IEnumerable<Interview> Interviews { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
