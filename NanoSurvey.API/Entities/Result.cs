using System.Collections.Generic;

namespace NanoSurvey.API.Entities
{
    public class Result
    {
        public Result()
        {
            Interviews = new List<Interview>();
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public IEnumerable<Interview> Interviews { get; private set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
