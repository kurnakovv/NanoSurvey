using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NanoSurvey.API.Entities
{
    public class Interview
    {
        public Interview()
        {
            Surveys = new List<Survey>();
        }

        public int Id { get; private set; }
        public IEnumerable<Survey> Surveys { get; private set; }
        [JsonIgnore]
        public Result Result { get; private set; }
    }
}
