using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NanoSurvey.API.Entities
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        [JsonIgnore]
        public Interview Interview { get; set; }
    }
}
