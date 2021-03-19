using System.Collections.Generic;

namespace NanoSurvey.Application.Entities
{
    public class Interview
    {
        public Interview()
        {
            Surveys = new List<Survey>();
        }

        public int Id { get; set; }
        public IEnumerable<Survey> Surveys { get; set; }
        public Result Result { get; set; }
    }
}
