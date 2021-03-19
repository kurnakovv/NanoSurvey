using System.Text.Json.Serialization;

namespace NanoSurvey.Application.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}
