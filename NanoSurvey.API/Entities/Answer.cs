using System.Text.Json.Serialization;

namespace NanoSurvey.API.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}
